using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interface
{
    public interface IAssetLocationService
    {
        Task<List<AssetLocation>> GetAllAsync();
        Task<AssetLocation> GetByIdAsync(int id);
        Task AddAsync(AssetLocation location);
        Task UpdateAsync(AssetLocation location);
        Task DeleteAsync(int id);
    }
}