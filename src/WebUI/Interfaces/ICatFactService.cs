namespace CatFactsApp.WebUI.Interfaces;

using CatFactsApp.WebUI.Models;

public interface ICatFactService
{
    Task<CatFact?> GetRandomCatFactAsync(CancellationToken cancellationToken = default);
}
