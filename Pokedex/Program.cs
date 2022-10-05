using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pokedex;
using MudBlazor.Services;
using Pokedex.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://pokeapi.co/api/v2/") });
builder.Services.AddScoped<IPokeApiClient, PokeApiClient>(); 
builder.Services.AddMudServices();
await builder.Build().RunAsync();
