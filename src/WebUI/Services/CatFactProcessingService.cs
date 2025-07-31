namespace CatFactsApp.WebUI.Services;

using CatFactsApp.WebUI.Interfaces;
using CatFactsApp.WebUI.Models;

public sealed class CatFactProcessingService : ICatFactProcessingService
{
    private readonly ICatFactService catFactService;
    private readonly IFileService fileService;
    private readonly ILogger<CatFactProcessingService> logger;

    public CatFactProcessingService(ICatFactService catFactService, IFileService fileService, ILogger<CatFactProcessingService> logger)
    {
        this.catFactService = catFactService;
        this.fileService = fileService;
        this.logger = logger;
    }

    public async Task<CatFact?> ProcessNewFactAsync(CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("Starting to process a new cat fact.");

        var catFact = await this.catFactService.GetRandomCatFactAsync(cancellationToken);

        if (catFact is null)
        {
            return null;
        }

        var content = $"{catFact.Fact} {catFact.Length}";

        try
        {
            await this.fileService.AppendToFileAsync(content, cancellationToken);
            this.logger.LogInformation("Successfully appended cat fact to file: {Content}", content);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Failed to append cat fact to file: {Content}", content);

            throw;
        }

        return catFact;
    }
}
