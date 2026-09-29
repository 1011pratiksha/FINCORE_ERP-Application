using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetLocationService : IAssetLocationService
    {
        private readonly ApplicationDbContext db;

        public AssetLocationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(AssetLocation location)
        {
            await db.AssetLocations.AddAsync(location);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.AssetLocations.FindAsync(id);
            db.AssetLocations.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetLocation>> GetAllAsync()
        {
            var data = await db.AssetLocations
                .Include(a => a.Asset)
                .ToListAsync();

            return data;
        }

        public async Task<AssetLocation> GetByIdAsync(int id)
        {
            return await db.AssetLocations.FindAsync(id);
        }

        public async Task UpdateAsync(AssetLocation location)
        {
            db.AssetLocations.Update(location);
            await db.SaveChangesAsync();
        }
    }
}
