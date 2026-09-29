using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interface
{
    public interface IAssetDepreciationService
    {
        Task<List<AssetDepreciation>> GetAllAsync();
        Task<AssetDepreciation> GetByIdAsync(int id);
        Task AddAsync(AssetDepreciation depreciation);
        Task UpdateAsync(AssetDepreciation depreciation);
        Task DeleteAsync(int id);
    }
}
