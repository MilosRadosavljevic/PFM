using AutoMapper;
using PFM.Database.Entities;
using PFM.Database.Repositories;
using PFM.Models;

namespace PFM.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        ITransactionRepository _transactionRepository;
        ICategoryRepository _categoryRepository;
        IMapper _mapper;
        public AnalyticsService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<SpendingByCategory<SpendingInCategory>> GetSpendingAnalytics(string? categoryCode, DateTime? startDate, DateTime? endDate, Direction? direction)
        {

            var spendings = await _transactionRepository.GetTransactionsByCategory(categoryCode, startDate, endDate, direction);

            return _mapper.Map<SpendingByCategory<SpendingInCategory>>(spendings);
        }
    }
}