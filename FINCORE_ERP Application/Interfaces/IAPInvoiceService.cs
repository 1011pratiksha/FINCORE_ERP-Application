using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IAPInvoiceService
    {
        public Task<List<APInvoice>> GetAllAPInvoices();
        public Task<string> AddAPInvoice(APInvoice ai);
        public Task<string> UpdateAPInvoice(APInvoice ai);
        public Task<string> DeleteAPInvoice(int id);
        public Task<string> GetAPInvoiceById(int id);
        public Task<string> ApproveAPInvoice(int id);
        public Task<string> RejectAPInvoice(int id);
        public Task<List<APInvoice>> GetAPInvoiceHistory();
    }
}
