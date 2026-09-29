using Microsoft.AspNetCore.Mvc;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Controllers
{
    public class AccountMasterController : Controller
    {
        IAccountMaster ams;
        public AccountMasterController(IAccountMaster ams)
        {
            this.ams = ams;
        }
        public async Task<IActionResult> Index()
        {
            var data = await ams.GetAllAccounts();
            return View(data);
        }

        public async Task<IActionResult> AddAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountMaster a)
        {
            await ams.AddAccount(a);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAccount(int id)
        {
            var data = await ams.GetAccountById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(AccountMaster a)
        {
            await ams.UpdateAccount(a);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAccount(int id)
        {
            await ams.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }

}
