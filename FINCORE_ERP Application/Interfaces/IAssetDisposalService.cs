using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IAssetDisposalService
    {
        Task<List<AssetDisposal>> GetAllAsync();
        Task<AssetDisposal> GetByIdAsync(int id);
        Task AddAsync(AssetDisposal disposal);
        Task UpdateAsync(AssetDisposal disposal);
        Task DeleteAsync(int id);
    }
}
