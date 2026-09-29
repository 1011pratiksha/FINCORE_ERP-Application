using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext db;
        public PaymentService(ApplicationDbContext db)
        {
            this.db = db;

        }
        public async Task<List<Payment>> GetAllPayments()
        {
            return await db.Payments.ToListAsync();
        }

        public async Task<string> AddPayment(Payment p)
        {
            await db.Payments.AddAsync(p);
            await db.SaveChangesAsync();
            return "Payment Added Successfully";
        }

        public async Task<string> UpdatePayment(Payment p)
        {
            db.Payments.Update(p);
            await db.SaveChangesAsync();
            return "Payment Updated Successfully";
        }

        public async Task<string> DeletePayment(int id)
        {
            var payment = await db.Payments.FindAsync(id);
            if (payment==null)
            {
                return "Payment not found";
            }
            db.Payments.Remove(payment);
            await db.SaveChangesAsync();
            return "Payment deleted Successfully";
        }

        public async Task<string> GetPaymentById(int id)
        {
            var payment = await db.Payments.FirstOrDefaultAsync(x => x.PaymentId == id);
            if (payment == null)
            {
                return "Payment not found";
            }
            return "Payment found";
        }

        public async Task<string> ApprovePayment(int id)
        {
            var payment = await db.Payments.FirstOrDefaultAsync(x => x.PaymentId == id);
            if (payment == null)
            {
                return "Payment not found";
            }
            payment.ApprovalStatus = "Approved";
            await db.SaveChangesAsync();
            return "Payment approved Successfully";
        }

        public async Task<string> RejectPayment(int id)
        {
            var payment = await db.Payments.FirstOrDefaultAsync(x => x.PaymentId == id);
            if (payment == null)
            {
                return "Payment not found";
            }
            payment.ApprovalStatus = "Rejected";
            await db.SaveChangesAsync();
            return "Payment rejected Successfully";
        }

        public async Task<List<Payment>> GetPaymentHistory()
        {
            return await db.Payments.ToListAsync();
        }


    }
}
