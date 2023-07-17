using AutoMapper;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Database.Repositories;
using PFM.Models;

namespace PFM.Services
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _repository;
        IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionCommand createTransactionCommand)
        {
            var checkIfTransactionExists = await CheckIfTransactionExistsAsync(createTransactionCommand.TransactionId);
            if (!checkIfTransactionExists)
            {
                var newTransactionEntity = _mapper.Map<TransactionEntity>(createTransactionCommand);
                await _repository.CreateTransaction(newTransactionEntity);
                return _mapper.Map<Transaction>(newTransactionEntity);
            }
            return null;
        }

        public async Task<PagedSortedList<Transaction>> GetTransactions(int page, int pageSize, SortOrder sortOrder, string? sortBy)
        {
            var transactions = await _repository.GetProducts(page, pageSize, sortOrder, sortBy);
            return _mapper.Map<PagedSortedList<Transaction>>(transactions);
        }


        private async Task<bool> CheckIfTransactionExistsAsync(string transactionId)
        {
            var transaction = await _repository.GetTransactionById(transactionId);
            if (transaction == null)
            {
                return false;
            }
            return true;
        }
    }
}
