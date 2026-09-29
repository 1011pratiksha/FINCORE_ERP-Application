using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class FinancialReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
