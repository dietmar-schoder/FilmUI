using FilmUI;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApiService, ApiService>();

var env = builder.HostEnvironment.Environment;
var configFile = env == "Production" ? "appconfig.production.json" : "appconfig.json";

var config = await builder.Services
    .BuildServiceProvider()
    .GetRequiredService<HttpClient>()
    .GetFromJsonAsync<AppConfig>(configFile);

builder.Services.AddSingleton(config);

await builder.Build().RunAsync();
