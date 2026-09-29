using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetDisposalService : IAssetDisposalService
    {
        private readonly ApplicationDbContext db;
        public AssetDisposalService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(AssetDisposal disposal)
        {
            await db.AssetDisposals.AddAsync(disposal);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.AssetDisposals.FindAsync(id);
            db.AssetDisposals.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetDisposal>> GetAllAsync()
        {
            var data = await db.AssetDisposals
               .Include(a => a.Asset)
               .ToListAsync();

            return data;
        }

        public async Task<AssetDisposal> GetByIdAsync(int id)
        {
            return await db.AssetDisposals.FindAsync(id);
        }

        public async Task UpdateAsync(AssetDisposal disposal)
        {
            db.AssetDisposals.Update(disposal);
            await db.SaveChangesAsync();
        }
    }
}
