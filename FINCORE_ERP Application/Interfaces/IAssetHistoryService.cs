using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interface
{
    public interface IAssetHistoryService
    {
        Task<List<AssetHistory>> GetAllAsync();
        Task<AssetHistory> GetByIdAsync(int id);
        Task AddAsync(AssetHistory history);
        Task UpdateAsync(AssetHistory history);
        Task DeleteAsync(int id);
    }
}
