namespace CatFactsApp.WebUI.Services;

using CatFactsApp.WebUI.Interfaces;
using CatFactsApp.WebUI.Models;

public sealed class CatFactService : ICatFactService
{
    private const string CLIENT_NAME = "ClientName";
    private const string FACT = "fact";
    private readonly IConfiguration configuration;
    private readonly IHttpClientFactory httpClientFactory;

    public CatFactService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        this.configuration = configuration;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<CatFact?> GetRandomCatFactAsync(CancellationToken cancellationToken = default)
    {
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
