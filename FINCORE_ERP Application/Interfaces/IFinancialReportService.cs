using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IFinancialReportService
    {
        Task<List<APInvoice>> GetAPReport();
        Task<List<Payment>> GetPaymentReport();
        Task<List<JournalEntry>> GetGLReport();
        Task<List<JournalEntry>> GetTrialBalance();
    }
}
