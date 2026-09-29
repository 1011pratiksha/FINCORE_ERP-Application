using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<List<Payment>> GetAllPayments();
        public Task<string> AddPayment(Payment p);
        public Task<string> UpdatePayment(Payment p);
        public Task<string> DeletePayment(int id);
        public Task<string> GetPaymentById(int id);
        public Task<string> ApprovePayment(int id);
        public Task<string> RejectPayment(int id);
        public Task<List<Payment>> GetPaymentHistory();
    }
}
