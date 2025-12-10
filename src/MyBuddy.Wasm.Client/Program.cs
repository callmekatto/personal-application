using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBuddy.Wasm.Client;
//using MyBuddy.WasmClient.Navigation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Entrypoint>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<Navigator>();
//builder.Services.AddScoped<Pipeline>();

await builder.Build().RunAsync();
