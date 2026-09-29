using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class APInvoiceService : IAPInvoiceService
    {
        private readonly ApplicationDbContext db;
        public APInvoiceService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<APInvoice>> GetAllAPInvoices()
        {
            return await db.APInvoices.ToListAsync();
        }

        public async Task<string> AddAPInvoice(APInvoice ai)
        {
            db.APInvoices.Add(ai);
            await db.SaveChangesAsync();
            return "APInvoice Added Successfully";
        }

        public async Task<string> UpdateAPInvoice(APInvoice ai)
        {
            db.APInvoices.Update(ai);
            await db.SaveChangesAsync();
            return "APInvoice Updated Successfully";
        }

        public async Task<string> DeleteAPInvoice(int id)
        {
            var Invoice = await db.APInvoices.FindAsync(id);
            if(Invoice==null)
            {
                return "Not found";
            }
            db.APInvoices.Remove(Invoice);
            await db.SaveChangesAsync();
            return "APInvoice Deleted Successfully";
        }

        public async Task<string> GetAPInvoiceById(int id)
        {
            var Invoice = await db.APInvoices.FirstOrDefaultAsync(x => x.APInvoiceId == id);
            if (Invoice == null)
            {
                return "Invoice not found";
            }
            return "Invoice found";
        }

        public async Task<string> ApproveAPInvoice(int id)
        {
            var Invoice = await db.APInvoices.FirstOrDefaultAsync(x => x.APInvoiceId == id);
            if (Invoice == null)
            {
                return "Invoice not found";
            }            
            Invoice.ApprovalStatus = "Approved";
            await db.SaveChangesAsync();
            return "Invoice approved Successfully";
        }

        public async Task<string> RejectAPInvoice(int id)
        {
            var Invoice = await db.APInvoices.FirstOrDefaultAsync(x => x.APInvoiceId == id);
            if (Invoice == null)
            {
                return "Invoice not found";
            }
            Invoice.ApprovalStatus = "Rejected";
            await db.SaveChangesAsync();
            return "Invoice Rejected Successfully";
        }

        public async Task<List<APInvoice>> GetAPInvoiceHistory()
        {
            return await db.APInvoices.ToListAsync();
        }
    }
}
