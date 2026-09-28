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
            await db.CapexRequests.AddAsync(cr);
            await db.SaveChangesAsync();
        }

        public async Task EditCapexRequest(CapexRequest cr)
        {
             db.CapexRequests.Update(cr);
            await db.SaveChangesAsync();

        }

        public async Task<List<CapexRequest>> fetchCapexRequests()
        {
            return await db.CapexRequests.ToListAsync();
        }
    }
}
