using Haters.BlazorClient;
using Haters.BlazorClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IPostService, PostService>();

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.RedirectUri = "https://localhost:7294/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:7294/authentication/logout-callback";
    options.ProviderOptions.Authority = "https://localhost:10001";
    options.ProviderOptions.ClientId = "client_blazor";
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("blazor");
    options.ProviderOptions.ResponseMode = "query";
    options.ProviderOptions.ResponseType = "code";

});

await builder.Build().RunAsync();
