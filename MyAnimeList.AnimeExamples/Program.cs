using Microsoft.Extensions.DependencyInjection;
using MyAnimeList.Net.API.Abstractions.API.Rest;
using MyAnimeList.Net.Rest.Extensions;

var credentials = File.ReadAllLines("credentials.txt");

var token = credentials[0];
var clientId = credentials[1];

var provider = new ServiceCollection()
    .AddMyAnimeListRest(token, clientId)
    .BuildServiceProvider();

var animeAPi = provider.GetRequiredService<IMyAnimeListAnimeAPI>();
var getAnime = await animeAPi.GetAnimeAsync(1575);

if (!getAnime.IsDefined(out var anime))
{
    Console.WriteLine("Error: " + getAnime.Error?.Message);
}

Console.WriteLine(anime!.Title);