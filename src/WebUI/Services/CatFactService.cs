namespace CatFactsApp.WebUI.Services;

using CatFactsApp.WebUI.Interfaces;
using CatFactsApp.WebUI.Models;

public sealed class CatFactService : ICatFactService
{
    private const string CLIENT_NAME = "ClientName";
    private const string FACT = "fact";
    private readonly IConfiguration configuration;
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<CatFactService> logger;

    public CatFactService(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<CatFactService> logger)
    {
        this.configuration = configuration;
        this.httpClientFactory = httpClientFactory;
        this.logger = logger;
    }

    public async Task<CatFact?> GetRandomCatFactAsync(CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Requesting a random cat fact from the API.");

        var httpClientName = this.configuration[CLIENT_NAME];
        var client = this.httpClientFactory.CreateClient(httpClientName ?? "");

        var response = await client.GetAsync(FACT, cancellationToken);

        if (response.IsSuccessStatusCode is true)
        {
            return await response.Content.ReadFromJsonAsync<CatFact>(cancellationToken: cancellationToken);
        }

        return null;
    }
}
