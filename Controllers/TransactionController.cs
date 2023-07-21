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
    [Route("v1/transactions")]
    public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;
        ITransactionSplitService _transactionSplitService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService, ITransactionSplitService transactionSplitService)
        {
            _logger = logger;
            _transactionService = transactionService;
            _transactionSplitService = transactionSplitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions (
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] SortOrder sortOrder = SortOrder.Asc,
            [FromQuery] string? sortBy = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] TransactionKind? transactionKind = null)
        {
            var transactions = await _transactionService.GetTransactions(page, pageSize, sortOrder, sortBy, startDate, endDate, transactionKind);
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

        //[HttpPost("{transactionid}/split")]
        //public async Task<IActionResult> SplitTransactions(string transactionId, [FromBody] List<TransactionSplitEntity> splits)
        //{
        //    var isSplited = await _transactionSplitService.SplitTransaction(transactionId, splits);
        //    if (isSplited)
        //    {
        //        return Ok("Transakcija je uspesno podeljena!");
        //    }
        //    return NotFound("Transakcija nije pronadjena!");
        //}

        [HttpPost("{transactionId}/categorize")]
        public async Task<IActionResult> CategorizeTransactions(string transactionId, [FromBody] CategorizeTransactionCommand categorizeTransactionCommand)
        {
            var transactionToCategorize = await _transactionService.CategorizeTransaction(transactionId, categorizeTransactionCommand);
            return Ok(transactionToCategorize);
            //return Ok();
        }

        //[HttpPost("auto-categorize")]
        //public IActionResult AutoCategorizeTransactions()
        //{
        //    return Ok();
        //}

    }
}
    