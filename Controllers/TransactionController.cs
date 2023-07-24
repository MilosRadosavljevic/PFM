﻿using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using PFM.Commands;
using PFM.Mappings;
using PFM.Services;
using System.Globalization;
using PFM.Models;
using System.ComponentModel;

namespace PFM.Controllers
{
    [ApiController]
    [Route("v1/transactions")]
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
        public async Task<IActionResult> GetTransactions (
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery(Name = "sort-order")] SortOrder sortOrder = SortOrder.Asc,
            [FromQuery(Name = "sort-by")] string? sortBy = null,
            [FromQuery(Name = "start-date")] DateTime? startDate = null,
            [FromQuery(Name = "end-date")] DateTime? endDate = null,
            [FromQuery(Name = "stransaction-kind")] string? transactionKind = null)
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

        [HttpPost("{id}/split")]
        public async Task<IActionResult> SplitTransactions([FromRoute] string id, [FromBody] SplitTransactionCommand splitTransactionCommand)
        {
            var transactionExists = await _transactionService.CheckIfTransactionExistsAsync(id);
            if(transactionExists == null)
            {
                return NotFound("Transaction doesn't exists!");
            }

            var transaction = await _transactionService.CreateTransactionSplit(id, splitTransactionCommand);

            return Ok(transaction);
        }

        [HttpPost("{id}/categorize")]
        [Description("Split transaction by category")]
        public async Task<IActionResult> CategorizeTransactions(string id, [FromBody] CategorizeTransactionCommand categorizeTransactionCommand)
        {
            try
            {
                var transactionToCategorize = await _transactionService.CategorizeTransaction(id, categorizeTransactionCommand);
                return Ok(transactionToCategorize);
            }
            catch
            {
                return NotFound("123");
            }                
        }

        //[HttpPost("auto-categorize")]
        //public IActionResult AutoCategorizeTransactions()
        //{
        //    return Ok();
        //}

    }
}
    