using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class PurchaseOrderController : Controller
    {
        IPurchaseOrderService service;

        public PurchaseOrderController(IPurchaseOrderService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllPurchaseOrders();

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await service.GetPurchaseOrderById(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrder p)
        {
            if (ModelState.IsValid)
            {
                await service.AddPurchaseOrder(p);

                return RedirectToAction("Index");
            }

            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await service.GetPurchaseOrderById(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseOrder p)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatePurchaseOrder(p);

                return RedirectToAction("Index");
            }

            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await service.GetPurchaseOrderById(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeletePurchaseOrder(id);

            return RedirectToAction("Index");
        }
    }
}