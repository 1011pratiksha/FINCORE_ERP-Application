using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetDepreciationService : IAssetDepreciationService
    {
        private readonly ApplicationDbContext db;

        public AssetDepreciationService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(AssetDepreciation depreciation)
        {
            await db.AssetDepreciations.AddAsync(depreciation);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.AssetDepreciations.FindAsync(id);
            db.AssetDepreciations.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetDepreciation>> GetAllAsync()
        {
            var data = await db.AssetDepreciations
                .Include(a => a.Asset)
                .ToListAsync();

            return data;
        }

        public async Task<AssetDepreciation> GetByIdAsync(int id)
        {
            return await db.AssetDepreciations.FindAsync(id);
        }

        public async Task UpdateAsync(AssetDepreciation depreciation)
        {
            db.AssetDepreciations.Update(depreciation);
            await db.SaveChangesAsync();
        }
    }
}
