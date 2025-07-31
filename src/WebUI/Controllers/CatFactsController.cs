namespace CatFactsApp.WebUI.Controllers;

using CatFactsApp.WebUI.Interfaces;

[Route("[controller]")]
public class CatFactsController : Controller
{
    private readonly ICatFactProcessingService catFactProcessingService;

    public CatFactsController(ICatFactProcessingService catFactProcessingService)
    {
        this.catFactProcessingService = catFactProcessingService;
    }

    [HttpGet, Route("RandomCatFact")]
    public async Task<IActionResult> GetRandomCatFactAsync(CancellationToken cancellationToken = default)
    {
        var fact = await this.catFactProcessingService.ProcessNewFactAsync(cancellationToken);

        if (fact is null)
        {
            return this.NotFound();
        }

        return this.Ok(fact);
    }

    [HttpGet]
    public IActionResult RandomFactView()
    {
        return this.View();
    }
}
