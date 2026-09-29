using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetHistoryService : IAssetHistoryService
    {
        private readonly ApplicationDbContext db;
        public AssetHistoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(AssetHistory history)
        {
            await db.AssetHistories.AddAsync(history);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.AssetHistories.FindAsync(id);
            db.AssetHistories.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetHistory>> GetAllAsync()
        {
            var data = await db.AssetHistories
               .Include(a => a.Asset)
               .Include(a => a.PerformedByUser)
               .ToListAsync();

            return data;
        }

        public async Task<AssetHistory> GetByIdAsync(int id)
        {
            return await db.AssetHistories.FindAsync(id);
        }

        public async Task UpdateAsync(AssetHistory history)
        {
            db.AssetHistories.Update(history);
            await db.SaveChangesAsync();
        }
    }
}
