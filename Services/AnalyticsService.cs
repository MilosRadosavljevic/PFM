using PFM.Database.Entities;
using PFM.Database.Repositories;
using PFM.Models;

namespace PFM.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        ITransactionRepository _transactionRepository;
        ICategoryRepository _categoryRepository;
        public AnalyticsService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<SpendingAnalytics> GetSpendingAnalytics(string? categoryCode, DateTime? startDate, DateTime? endDate, Direction? direction)
        {
            List<TransactionEntity> transactions;

            if (string.IsNullOrEmpty(categoryCode))
            {
                transactions = await _transactionRepository.GetAllTransactionsForAnalytics(categoryCode, startDate, endDate, direction);

                var spendingAnalytics = transactions
                    .Where(c => c.catCode != null)
                    .GroupBy(t => t.catCode)
                    .Select(g => new SpendingAnalyticsGroup
                    {
                        CatCode = g.Key,
                        Amount = Math.Round(g.Sum(x => x.Amount), 2),
                        Count = g.Count()
                    })
                    .ToList();

                var categories = await _categoryRepository.GetAllCategories();

                foreach (var group in spendingAnalytics.ToList())
                {
                    var category = categories.FirstOrDefault(c => c.Code == group.CatCode);
                    if (category != null && !string.IsNullOrEmpty(category.ParentCode))
                    {
                        // Kategorija ima parent-code, što znači da je podkategorija
                        var mainCategory = categories.FirstOrDefault(c => c.Code == category.ParentCode);
                        if (mainCategory != null)
                        {
                            // Pronađena je osnovna kategorija, treba joj dodati potrošnju
                            var mainGroup = spendingAnalytics.FirstOrDefault(g => g.CatCode == mainCategory.Code);
                            if (mainGroup != null || mainCategory.Code != null)
                            {
                                mainGroup.Amount += group.Amount;
                                mainGroup.Count += group.Count;
                                // Ukloniti podkategoriju iz liste
                                spendingAnalytics.Remove(group);
                            }
                        }
                    }
                }
                return new SpendingAnalytics
                {
                    Groups = spendingAnalytics
                };
            }
            else
            {
                transactions = await _transactionRepository.GetTransactionsByCategory(categoryCode, startDate, endDate, direction);

                var spendingAnalytics = transactions
                    .Where(c => c.catCode != null)
                    .GroupBy(t => t.catCode)
                    .Select(g => new SpendingAnalyticsGroup
                    {
                        CatCode = g.Key,
                        Amount = Math.Round(g.Sum(x => x.Amount), 2),
                        Count = g.Count()
                    })
                    .ToList();

                return new SpendingAnalytics
                {
                    Groups = spendingAnalytics
                };

            }
        }
    }
}