namespace CatFactsApp.WebUI;

using CatFactsApp.WebUI.Interfaces;
using CatFactsApp.WebUI.Services;

public static class DependencyInjection
{
    private const string CLIENT_NAME = "ClientName";

    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        var httpClientName = configuration[CLIENT_NAME] ?? "";

        services.AddHttpClient(httpClientName,
            client =>
            {
                client.BaseAddress = new Uri("https://catfact.ninja/");
            });

        services.AddScoped<ICatFactService, CatFactService>();
        services.AddScoped<IFileService, FileService>();

        return services;
    }

    public static IApplicationBuilder UseWebApi(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var fileService = scope.ServiceProvider.GetRequiredService<IFileService>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            fileService.ClearFileAsync().GetAwaiter().GetResult();
            logger.LogInformation("File cleaned successfully on startup");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while cleaning the file");
        }

        return app;
    }
}
