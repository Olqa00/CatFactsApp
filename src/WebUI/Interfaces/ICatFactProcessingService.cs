namespace CatFactsApp.WebUI.Interfaces;

using CatFactsApp.WebUI.Models;

public interface ICatFactProcessingService
{
    Task<CatFact?> ProcessNewFactAsync(CancellationToken cancellationToken = default);
}
