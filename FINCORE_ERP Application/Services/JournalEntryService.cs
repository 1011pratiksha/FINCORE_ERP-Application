using FINCORE_ERP_Application.Models;
using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FINCORE_ERP_Application.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        private readonly ApplicationDbContext db;
        public JournalEntryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddEntry(JournalEntry j)
        {
            await db.JournalEntries.AddAsync(j);
            await db.SaveChangesAsync();
            return "Entry Added Successfully";
        }

        public async Task<string> DeleteEntry(int id)
        {
            var entry = await db.JournalEntries.FindAsync(id);
            if(entry==null)
            {
                return "Entry not found";
            }
            db.JournalEntries.Remove(entry);
            await db.SaveChangesAsync();
            return "Entry deleted Successfully";
        }

        public async Task<List<JournalEntry>> GetAllEntries()
        {
            return await db.JournalEntries.ToListAsync();
        }

        public async Task<string> GetEntryById(int id)
        {
            var entry = await db.JournalEntries.FirstOrDefaultAsync(x => x.JournalEntryId == id);
            if (entry == null)
            {
                return "Entry not found";
            }
            return "Entry found";
        }

        public async Task<string> UpdateEntry(JournalEntry j)
        {
            db.JournalEntries.Update(j);
            await db.SaveChangesAsync();
            return "Entry Updated Successfully";
        }

        public async Task<List<JournalEntry>> GetGLReport()
        {
            return await db.JournalEntries.Include(x => x.AccountMaster).ToListAsync();
        }
    }
}
