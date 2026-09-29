using FINCORE_ERP_Application.Models;
using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AccountMasterService : IAccountMaster
    {
        private readonly ApplicationDbContext db;
        public AccountMasterService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddAccount(AccountMaster am)
        {
            await db.AccountMasters.AddAsync(am);
            await db.SaveChangesAsync();
            return "Account Added Successfully";
        }

        public  async Task<string> DeleteAccount(int id)
        {
            var account = await db.AccountMasters.FindAsync(id);
            if(account==null)
            {
                return "Account not found";
            }
            db.AccountMasters.Remove(account);
            await db.SaveChangesAsync();
            return "Account deleted Successfully";
        }

        public async Task<AccountMaster> GetAccountById(int id)
        {
            var account = await db.AccountMasters.FirstOrDefaultAsync(x => x.AccountId == id);
            return account;
        }

        public async Task<List<AccountMaster>> GetAllAccounts()
        {
            return await db.AccountMasters.ToListAsync();
        }

        public async Task<string> UpdateAccount(AccountMaster am)
        {
            db.AccountMasters.Update(am);
            await db.SaveChangesAsync();
            return "Account updated Successfully";
        }
    }
}
