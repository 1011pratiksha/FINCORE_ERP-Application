using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class BudgetController : Controller
    {
        IBudgetService service;

        public BudgetController(IBudgetService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var budgets = await service.fetchBudgets();
            return View(budgets);
        }

        [HttpPost]
        public async Task<IActionResult> AddBudget(Budget b)
        {
            await service.createBudget(b);
            return RedirectToAction("Index");
        } 
       

    }
}
