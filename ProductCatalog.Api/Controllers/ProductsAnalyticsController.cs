using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Domain.Repositories;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/products/analytics")]
public class ProductsAnalyticsController : ControllerBase
{
    private readonly IProductAnalyticsRepository _analyticsRepository;

    public ProductsAnalyticsController(IProductAnalyticsRepository analyticsRepository)
    {
        _analyticsRepository = analyticsRepository;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<ProductAnalyticsSummary>> GetSummary()
    {
        var summary = await _analyticsRepository.GetSummaryAsync();
        return Ok(summary);
    }
}
