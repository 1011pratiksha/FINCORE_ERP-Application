using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class RevenueEntryService : IRevenueEntryService
    {
        private readonly ApplicationDbContext db;
        public RevenueEntryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(RevenueEntry revenueEntry)
        {
            await db.RevenueEntries.AddAsync(revenueEntry);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.RevenueEntries.FindAsync(id);
            db.RevenueEntries.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<RevenueEntry>> GetAllAsync()
        {
            var data = await db.RevenueEntries
                .Include(r => r.Customer)
                .Include(r => r.Department)
                .Include(r => r.AccountMaster)
                .Include(r => r.CreatedByUser)
                .Include(r => r.ModifiedByUser)
                .ToListAsync();

            return data;
        }

        public async Task<RevenueEntry> GetByIdAsync(int id)
        {
            return await db.RevenueEntries.FindAsync(id);
        }

        public async Task UpdateAsync(RevenueEntry revenueEntry)
        {
            db.RevenueEntries.Update(revenueEntry);
            await db.SaveChangesAsync();
        }
    }
}
