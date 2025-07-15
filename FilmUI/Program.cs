using Blazored.LocalStorage;
using FilmUI;
using FilmUI.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<ISlackService, SlackService>();
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddScoped<ISessionService, SessionService>();

var env = builder.HostEnvironment.Environment;
var configFile = env == "Production" ? "appconfig.production.json" : "appconfig.json";

var config = await builder.Services
    .BuildServiceProvider()
    .GetRequiredService<HttpClient>()
    .GetFromJsonAsync<AppConfig>(configFile);

builder.Services.AddSingleton(config);
builder.Services.AddBlazoredLocalStorage();

var host = builder.Build();
var session = host.Services.GetRequiredService<ISessionService>() as SessionService;
await session.InitializeAsync();
await host.RunAsync();
