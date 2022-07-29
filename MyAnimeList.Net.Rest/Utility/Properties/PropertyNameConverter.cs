using System.Reflection;
using System.Text.Json;
using Remora.Rest.Json;
using Remora.Rest.Json.Policies;
using Remora.Results;

namespace MyAnimeList.Net.Rest.Utility.Properties;

/// <summary>
/// Converts property names to the given naming policy.
/// </summary>
public static class PropertyNameConverter
{
    /// <summary>
    /// Converts the property names. All the properties must have the same declaring type.
    /// </summary>
    /// <param name="properties">The properties to convert.</param>
    /// <param name="jsonOptions">The JSON options to retrieve overriden JSON names from.</param>
    /// <param name="namingPolicy">The naming policy to use.</param>
    /// <returns>The converted property names.</returns>
    public static Result<PropertyNameStore> ConvertProperties
    (
        IReadOnlyList<PropertyInfo> properties,
        JsonSerializerOptions jsonOptions,
        JsonNamingPolicy? namingPolicy = default
    )
    {
        namingPolicy ??= new SnakeCaseNamingPolicy();

        if (properties.Count == 0)
        {
            return new PropertyNameStore(Array.Empty<PropertyInfo>(), Array.Empty<string>());
        }

        var sampleProperty = properties[0];
        if (sampleProperty.DeclaringType is null)
        {
            return new ArgumentInvalidError(nameof(properties), "The given properties must all have a declaring type.");
        }
        
        var implementations = GetImplementingTypes(Assembly.Load("MyAnimeList.API"), sampleProperty.DeclaringType);
        if (implementations.Count != 1)
        {
            return new ArgumentInvalidError(nameof(properties), "The given properties' declaring type must have exactly one API implementation.");
        }
        
        var implementation = implementations[0];
        if (implementation is null)
        {
            return new ArgumentInvalidError(nameof(properties), "The given properties' declaring type API implementation must not be null.");
        }

        var typeToMatch = typeof(DataObjectConverter<,>).MakeGenericType(sampleProperty.DeclaringType, implementation);
        
        var dataObjectConverter = jsonOptions.Converters.FirstOrDefault(c => c.GetType() == typeToMatch);
        if (dataObjectConverter is null)
        {
            return new PropertyNameStore(properties, ConvertAll(properties, namingPolicy));
        }
        
        var writeNameOverridesField = dataObjectConverter.GetType().GetField("_writeNameOverrides", BindingFlags.Instance | BindingFlags.NonPublic);
        if (writeNameOverridesField is null || 
            writeNameOverridesField.FieldType != typeof(Dictionary<PropertyInfo, string>))
        {
            return new PropertyNameStore(properties, ConvertAll(properties, namingPolicy));
        }
        
        var writeNameOverrides =  (Dictionary<PropertyInfo, string>?) writeNameOverridesField.GetValue(dataObjectConverter);
        if (writeNameOverrides is null or { Count: 0 })
        {
            return new PropertyNameStore(properties, ConvertAll(properties, namingPolicy));
        }

        var writeNameStringOverrides = writeNameOverrides.ToDictionary(kvp => kvp.Key.Name, kvp => kvp.Value); 
        
        var names = new List<string>();
        
        foreach (var property in properties)
        {
            if (writeNameStringOverrides.ContainsKey(property.Name))
            {
                names.Add(writeNameStringOverrides[property.Name]);
                continue;
            }
            
            names.Add(namingPolicy.ConvertName(property.Name));
        }

        return new PropertyNameStore(properties, names);
    }

    private static IReadOnlyList<string> ConvertAll(IEnumerable<PropertyInfo> properties, JsonNamingPolicy namingPolicy)
    {
        return properties.Select(p => namingPolicy.ConvertName(p.Name)).ToList(); 
    }

    private static IReadOnlyList<Type?> GetImplementingTypes(Assembly assembly, Type type)
    {
        return GetLoadableTypes(assembly).Where(type.IsAssignableFrom).ToList();
    }
    
    private static IEnumerable<Type?> GetLoadableTypes(Assembly assembly) 
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }
        try 
        {
            return assembly.GetTypes();
        } 
        catch (ReflectionTypeLoadException e)
        {
            return e.Types.Where(t => t is not null);
        }
    }
}