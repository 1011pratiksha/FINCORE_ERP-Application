using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetService : IAssetService
    {
        private readonly ApplicationDbContext db;
        public async Task AddAsync(Asset a)
        {
            await db.Assets.AddAsync(a);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var data = await db.Assets.FindAsync(id);
           db.Assets.Remove(data);
           await db.SaveChangesAsync();

        }

        public async Task<List<Asset>> GetAllAsync()
        {
            var data = await db.Assets
               .Include(a => a.Vendor)
               .Include(a => a.Department)
               .Include(a => a.CapexRequest)
               .ToListAsync();

            return data;
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            return await db.Assets.FindAsync(id);
        }

        public async Task UpdateAsync(Asset a)
        {
            db.Assets.Update(a);
            await db.SaveChangesAsync();
         }
    }
}
