using System;
using System.Net.Http;
using BlazorGenericsAndReflection;
using BlazorGenericsAndReflection.BusinessLogic.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<FeatureImplementationService>();

await builder.Build().RunAsync();
