using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class CapexController : Controller
    {
        ICapexRequestService service;

        public CapexController(ICapexRequestService service)
        {
            this.service = service;
            
        }
        public async Task<IActionResult> Index()
        {
            var capex =await service.fetchCapexRequests();
            return View(capex);
        }

        [HttpPost]
        public async Task<IActionResult> AddCapexRequest(CapexRequest cr)
        {
            await service.AddCapexRequest(cr);
            return RedirectToAction("Index");
        }
    }
}
