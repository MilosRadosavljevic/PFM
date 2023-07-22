using AutoMapper;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Database.Repositories;
using PFM.Models;

namespace PFM.Services
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository;
        ICategoryRepository _categoryRepository;
        IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionCommand createTransactionCommand)
        {
            var checkIfTransactionExists = await CheckIfTransactionExistsAsync(createTransactionCommand.TransactionId);
            if (!checkIfTransactionExists)
            {
                var newTransactionEntity = _mapper.Map<TransactionEntity>(createTransactionCommand);
                await _transactionRepository.CreateTransaction(newTransactionEntity);
                return _mapper.Map<Transaction>(newTransactionEntity);
            }
            return null;
        }

        public async Task<PagedSortedListTransactions<Transaction>> GetTransactions(
            int page,
            int pageSize,
            SortOrder sortOrder,
            string? sortBy,
            DateTime? startDate,
            DateTime? endDate,
            TransactionKind? transactionKind)
        {
            var transactions = await _transactionRepository.GetTransactions(page, pageSize, sortOrder, sortBy,
                startDate, endDate, transactionKind);
            return _mapper.Map<PagedSortedListTransactions<Transaction>>(transactions);
        }


        public async Task<bool> CheckIfTransactionExistsAsync(string transactionId)
        {
            var transaction = await _transactionRepository.GetTransactionById(transactionId);
            if (transaction == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Transaction> CategorizeTransaction(string transctionId, CategorizeTransactionCommand categorizeTransactionCommand)
        {
            var transaction = await _transactionRepository.GetTransactionById(transctionId);
            var category = await _categoryRepository.GetCategoryByCode(categorizeTransactionCommand.CategoryCode);

            if (transaction == null || category == null)
            {
                throw new Exception("Invalid transaction or category.");
            }

            transaction.catCode = categorizeTransactionCommand.CategoryCode;
            await _transactionRepository.UpdateTransaction(transaction);
            return _mapper.Map<Transaction>(transaction);
        }

        public async Task<Transaction> CreateTransactionSplit(string transactionId, SplitTransactionCommand splitTransactionCommand)
        {
            double totalAmount = 0;
            var transactionEntity = await _transactionRepository.GetTransactionById(transactionId);

            if (transactionEntity == null)
            {
                return null;
            }

            foreach (var split in splitTransactionCommand.Splits)
            {
                var category = await _categoryRepository.GetCategoryByCode(split.CategoryCode);
                if (category == null)
                {
                    return null;
                }

                totalAmount += split.Amount;
            }

            if (totalAmount != transactionEntity.Amount)
            {
                return null;
            }

            await _transactionRepository.DeleteTransactionSplits(transactionEntity);

            foreach (var split in splitTransactionCommand.Splits)
            {
                if (split.Amount == 0)
                {
                    return null;
                }

                var splitEntity = new TransactionSplitEntity
                {
                    TransactionId = transactionEntity.Id,
                    CategoryCode = split.CategoryCode,
                    Amount = split.Amount
                };

                
                await _transactionRepository.CreateTransactionSplit(splitEntity);
            }

            var transaction = _mapper.Map<Transaction>(transactionEntity);

            return transaction;
        }
    }
}