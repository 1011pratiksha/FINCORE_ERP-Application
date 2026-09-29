using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interface
{
    public interface IAssetAssignmentService
    {
        Task<List<AssetAssignment>> GetAllAsync();
        Task<AssetAssignment> GetByIdAsync(int id);
        Task AddAsync(AssetAssignment assignment);
        Task UpdateAsync(AssetAssignment assignment);
        Task DeleteAsync(int id);
    }
}