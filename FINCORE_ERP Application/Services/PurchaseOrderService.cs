using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        ApplicationDbContext db;

        public PurchaseOrderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPurchaseOrder(PurchaseOrder p)
        {
            await db.PurchaseOrders.AddAsync(p);
            await db.SaveChangesAsync();
        }

        public async Task DeletePurchaseOrder(int id)
        {
            var data = await db.PurchaseOrders.FindAsync(id);
            if (data != null)
            {
                db.PurchaseOrders.Remove(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            var data = await db.PurchaseOrders.ToListAsync();
            return data;
        }

        public async Task<PurchaseOrder> GetPurchaseOrderById(int id)
        {
            var data = await db.PurchaseOrders.FindAsync(id);
            return data;
        }

        public async Task UpdatePurchaseOrder(PurchaseOrder p)
        {
            db.PurchaseOrders.Update(p);
            await db.SaveChangesAsync();
        }
    }
}