using PFM.Models;

namespace PFM.Services
{
    public interface IAnalyticsService
    {
        public Task<SpendingAnalytics> GetSpendingAnalytics(string? categoryCode, DateTime? startDate, DateTime? endDate, Direction? direction);
    }
}
