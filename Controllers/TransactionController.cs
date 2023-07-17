using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using PFM.Commands;
using PFM.Mappings;
using PFM.Models;
using PFM.Services;
using System.Globalization;

namespace PFM.Controllers
{
    [ApiController]
    [Route("v1/transcations")]
    public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] int pageSize = 20, [FromQuery] int page = 1, [FromQuery] SortOrder sortOrder = SortOrder.Asc, [FromQuery] string? sortBy = null)
        {
            var transactions = await _transactionService.GetTransactions(page, pageSize, sortOrder, sortBy);
            return Ok(transactions);
        }


        [HttpPost("import")]
        public async Task<IActionResult> ImportTransactions(IFormFile file)
        {
            try
            {
                file = Request.Form.Files[0];
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TransactionMap>();
                    var records = csv.GetRecords<CreateTransactionCommand>().ToList();
                    foreach (var record in records)
                    {
                        await _transactionService.CreateTransaction(record);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error importing transactions.");
                return StatusCode(500, "An error occurred while importing transactions.");
            }
        }

        [HttpPost("{transactionId}/split")]
        public IActionResult SplitTransactions()
        {
            return Ok();
        }

        [HttpPost("{transactionId}/categorize")]
        public IActionResult CategorizeTransactions()
        {
            return Ok();
        }

        [HttpPost("auto-categorize")]
        public IActionResult AutoCategorizeTransactions()
        {
            return Ok();
        }

    }
}
    