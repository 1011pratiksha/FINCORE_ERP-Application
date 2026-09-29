using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class ARInvoiceService : IARInvoiceService
    {
        private readonly ApplicationDbContext db;
        public ARInvoiceService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(ARInvoice invoice)
        {
            await db.ARInvoices.AddAsync(invoice);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.ARInvoices.FindAsync(id);
            db.ARInvoices.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<ARInvoice>> GetAllAsync()
        {
            var data = await db.ARInvoices
                .Include(a => a.Customer)
                .Include(a => a.RevenueEntry)
                .ToListAsync();

            return data;
        }

        public async Task<ARInvoice> GetByIdAsync(int id)
        {
            return await db.ARInvoices.FindAsync(id);   
        }

        public async Task UpdateAsync(ARInvoice invoice)
        {
            db.ARInvoices.Update(invoice);
            await db.SaveChangesAsync();
        }
    }
}
