using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class OpexController : Controller
    {
        IOpexRequestService service;
        public OpexController(IOpexRequestService service)
        {
            this.service = service;

        }
        public async Task<IActionResult> Index()
        {
            var opex=await service.fetchOpexRequests();
            return View(opex);
        }

        public async Task<IActionResult> addOpexRequest(OpexRequest opexRequest) {
            await service.createOpexRequest(opexRequest);
            return RedirectToAction("Index");
        }

    }
}
