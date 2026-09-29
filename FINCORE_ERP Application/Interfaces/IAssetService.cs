using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interface
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync(int id);
        Task AddAsync(Asset a);
        Task UpdateAsync(Asset a);
        Task DeleteAsync(int id);
    }
}