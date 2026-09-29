using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IJournalEntryService
    {
        public Task<List<JournalEntry>> GetAllEntries();
        public Task<string> AddEntry(JournalEntry j);
        public Task<string> UpdateEntry(JournalEntry j);
        public Task<string> DeleteEntry(int id);
        public Task<string> GetEntryById(int id);
        public Task<List<JournalEntry>> GetGLReport();
    }
}
