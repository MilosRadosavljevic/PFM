using Microsoft.AspNetCore.Mvc;
using PFM.Models;
using PFM.Services;

namespace PFM.Controllers
{
    [ApiController]
    [Route("v1/spending-analytics")]
    public class AnalyticsController : ControllerBase
    {
        IAnalyticsService _analyticsService;
        private readonly ILogger<TransactionController> _logger;

        public AnalyticsController(ILogger<TransactionController> logger, IAnalyticsService analyticsService)
        {
            _logger = logger;
            _analyticsService = analyticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpendingAnalytics(
            [FromQuery] string? categoryCode,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] Direction? direction)
        {
            var spendingAnalytics = await _analyticsService.GetSpendingAnalytics(categoryCode, startDate, endDate, direction);
            return Ok(spendingAnalytics);
        }
    }
}
