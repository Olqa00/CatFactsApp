namespace CatFactsApp.WebUI.Controllers;

using CatFactsApp.WebUI.Interfaces;

[Route("[controller]")]
public class CatFactsController : Controller
{
    private readonly ICatFactService catFactService;

    public CatFactsController(ICatFactService catFactService)
    {
        this.catFactService = catFactService;
    }

    [HttpGet, Route("RandomCatFact")]
    public async Task<IActionResult> GetRandomCatFactAsync(CancellationToken cancellationToken = default)
    {
        var catFact = await this.catFactService.GetRandomCatFactAsync(cancellationToken);

        if (catFact is null)
        {
            return this.NotFound();
        }

        return this.Ok(catFact);
    }

    [HttpGet]
    public IActionResult RandomFactView()
    {
        return this.View();
    }
}
