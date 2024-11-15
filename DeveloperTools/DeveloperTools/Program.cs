using DeveloperTools.Pages.Tools.JsonFormatter;
using DeveloperTools.Shared;
using Microsoft.FluentUI.AspNetCore.Components;

public class Program
{
    private static async Task Main(string[] args)
    {
        await BuildWebHost(args).RunAsync();
    }

    public static IHost BuildWebHost(string[]? args = default)
    {
        var builder = WebApplication.CreateBuilder(args ?? Array.Empty<string>());
        ConfigureServices(builder.Services);

        var app = builder.Build();

        ConfigureMiddleware(app);

        return app;
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorComponents()
               .AddInteractiveServerComponents();

        services.AddFluentUIComponents();
        services.AddSingleton<JsonFormatter>();
    }

    public static void ConfigureMiddleware(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", true);
            app.UseHsts();
        }

        app.UseHttpsRedirection()
           .UseStaticFiles()
           .UseAntiforgery();

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();
    }
}