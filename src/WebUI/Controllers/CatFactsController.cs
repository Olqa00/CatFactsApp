namespace CatFactsApp.WebUI.Controllers;

using CatFactsApp.WebUI.Interfaces;

[Route("[controller]")]
public class CatFactsController : Controller
{
    private readonly ICatFactService catFactService;
    private readonly IFileService fileService;

    public CatFactsController(ICatFactService catFactService, IFileService fileService)
    {
        this.catFactService = catFactService;
        this.fileService = fileService;
    }

    [HttpGet, Route("RandomCatFact")]
    public async Task<IActionResult> GetRandomCatFactAsync(CancellationToken cancellationToken = default)
    {
        var catFact = await this.catFactService.GetRandomCatFactAsync(cancellationToken);

        if (catFact is null)
        {
            return this.NotFound();
        }

        var content = catFact.Fact + " " + catFact.Length;

        await this.fileService.AppendToFileAsync(content, cancellationToken);

        return this.Ok(catFact);
    }

    [HttpGet]
    public IActionResult RandomFactView()
    {
        return this.View();
    }
}
