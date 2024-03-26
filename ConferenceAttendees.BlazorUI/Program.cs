using ConferenceAttendees.BlazorUI;
using ConferenceAttendees.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    //BaseAddress = new Uri("http://conferenceattendees.api")
    BaseAddress = new Uri("http://api.conferenceattendees.com:7106")
});
builder.Services.AddScoped<IClient, Client>(); 
await builder.Build().RunAsync();
