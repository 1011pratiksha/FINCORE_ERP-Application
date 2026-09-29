using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IRevenueEntryService
    {
        Task<List<RevenueEntry>> GetAllAsync();
        Task<RevenueEntry> GetByIdAsync(int id);
        Task AddAsync(RevenueEntry revenueEntry);
        Task UpdateAsync(RevenueEntry revenueEntry);
        Task DeleteAsync(int id);
    }
}
