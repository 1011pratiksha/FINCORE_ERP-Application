using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private readonly ApplicationDbContext db;

        public AssetAssignmentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(AssetAssignment assignment)
        {
            await db.AssetAssignments.AddAsync(assignment);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.AssetAssignments.FindAsync(id);
            db.AssetAssignments.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetAssignment>> GetAllAsync()
        {
            var data = await db.AssetAssignments
            .Include(a => a.Asset)
            .Include(a => a.Employee)
            .ToListAsync();

            return data;
        }

        public async Task<AssetAssignment> GetByIdAsync(int id)
        {
            return await db.AssetAssignments.FindAsync(id);
        }

        public async Task UpdateAsync(AssetAssignment assignment)
        {
            db.AssetAssignments.Update(assignment);
            await db.SaveChangesAsync();
        }
    }
}