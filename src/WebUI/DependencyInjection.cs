namespace CatFactsApp.WebUI;

using CatFactsApp.WebUI.Interfaces;
using CatFactsApp.WebUI.Services;

public static class DependencyInjection
{
    private const string ADDRESS = "WebAddress";
    private const string CLIENT_NAME = "ClientName";

    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();

        services.AddScoped<ICatFactService, CatFactService>();
        services.AddScoped<IFileService, FileService>();

        var httpClientName = configuration[CLIENT_NAME] ?? "";
        var webAddress = configuration[ADDRESS] ?? "";

        services.AddHttpClient(httpClientName,
            client =>
            {
                client.BaseAddress = new Uri(webAddress);
            });

        services.AddSingleton<FileSettings>();
        services.AddHostedService<FileHostedService>();

        return services;
    }
}
