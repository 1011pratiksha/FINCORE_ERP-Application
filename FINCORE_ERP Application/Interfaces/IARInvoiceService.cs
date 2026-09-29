using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IARInvoiceService
    {
        Task<List<ARInvoice>> GetAllAsync();
        Task<ARInvoice> GetByIdAsync(int id);
        Task AddAsync(ARInvoice invoice);
        Task UpdateAsync(ARInvoice invoice);
        Task DeleteAsync(int id);
    }
}
