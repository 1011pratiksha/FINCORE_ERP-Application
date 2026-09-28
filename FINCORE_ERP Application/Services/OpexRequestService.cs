using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class OpexRequestService : IOpexRequestService
    {
        ApplicationDbContext db;

        public OpexRequestService(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        public async Task createOpexRequest(OpexRequest or)
        {
            await db.OpexRequests.AddAsync(or);
            await db.SaveChangesAsync();
        }

        public async Task EditOpexRequest(OpexRequest or)
        {
            db.OpexRequests.Update(or);
            await db.SaveChangesAsync();
        }

        public async Task<List<OpexRequest>> fetchOpexRequests()
        {
            return await db.OpexRequests.ToListAsync();
        }
    }
}
