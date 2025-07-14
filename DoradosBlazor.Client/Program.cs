using DoradosBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DoradosBlazor.Client.Services;
using DoradosBlazor.Shared;
using CurrieTechnologies.Razor.SweetAlert2;

using Blazored.SessionStorage;
using Microsoft.JSInterop;

using Radzen;

using Microsoft.AspNetCore.Components.Authorization;
using DoradosBlazor.Client.Extensiones;

using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-MX");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<DialogService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5296/") });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<SesionEmail>();
builder.Services.AddScoped<SesionUsuario>();
builder.Services.AddScoped<QRService>();

builder.Services.AddBlazorBootstrap();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
