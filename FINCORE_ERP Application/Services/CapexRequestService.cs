using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class CapexRequestService : ICapexRequestService
    {
        ApplicationDbContext db;
        public CapexRequestService(ApplicationDbContext db)
        {
            this.db= db;
        }

        public async Task AddCapexRequest(CapexRequest cr)
        {
            cr.CreatedAt = DateTime.Now;
            cr.ApprovalStatus = "Pending";
            cr.IsActive = 1;
            await db.CapexRequests.AddAsync(cr);
            await db.SaveChangesAsync();
        }

        public async Task EditCapexRequest(CapexRequest cr)
        {
            cr.ModifiedAt = DateTime.Now;
             db.CapexRequests.Update(cr);
            await db.SaveChangesAsync();

        }

        public async Task<List<CapexRequest>> fetchCapexRequests()
        {
            return await db.CapexRequests.Include(c => c.Department).Include(c => c.ApprovedByUser).Include(c => c.ModifiedByUser).Include(c => c.CreatedByUser)
                .Include(c => c.RequestedByUser).Include(c => c.BudgetLine).ThenInclude(bl => bl.BudgetCategory).Include(c => c.BudgetLine).ThenInclude(bl => bl.Budget).ToListAsync();
        }
    }
}
