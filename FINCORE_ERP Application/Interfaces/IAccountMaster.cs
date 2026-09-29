using FINCORE_ERP_Application.Models;
namespace FINCORE_ERP_Application.Interfaces
{
    public interface IAccountMaster
    {
        public Task<List<AccountMaster>> GetAllAccounts();
        public Task<string> AddAccount(AccountMaster am);
        public Task<string> UpdateAccount(AccountMaster am);
        public Task<string> DeleteAccount(int id);
        public Task<AccountMaster> GetAccountById(int id);
    }
}
