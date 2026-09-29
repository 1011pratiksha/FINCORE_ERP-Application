using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class VendorController : Controller
    {
        IVendorService service;

        public VendorController(IVendorService vendorService)
        {
            service = vendorService;
        }

        public async Task <IActionResult> Index()
        {
            await service.GetVendor();
            return View();
        }
        //public async Task<IActionResult> Index()
        //{
        //    var data = await service.GetVendor();
        //    return View(data);
        //}

        public async Task<IActionResult> Create()
        {
            ViewBag.VendorCategories = await service.GetVendorCategories();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vendor v)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VendorCategories = await service.GetVendorCategories();

                return View(v);
            }

            v.CreatedAt = DateTime.Now;
            v.ModifiedAt = DateTime.Now;

            await service.AddVendor(v);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var vendor = await service.GetVendorById(id);

            return View(vendor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vendor = await service.GetVendorById(id);

            ViewBag.VendorCategories = await service.GetVendorCategories();

            return View(vendor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vendor v)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VendorCategories = await service.GetVendorCategories();

                return View(v);
            }

            await service.UpdateVendor(v);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var vendor = await service.GetVendorById(id);

            return View(vendor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DelVendor(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Performance(int id)
        {
            var vendor = await service.GetVendorById(id);

            return View(vendor);
        }

        [HttpPost]
        public async Task<IActionResult> Performance(int id, decimal performanceScore)
        {
            await service.UpdatePerformanceScore(id, performanceScore);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Verify(int id, byte verified)
        {
            await service.UpdateVerification(id, verified);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, byte status)
        {
            await service.UpdateStatus(id, status);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> History(int id)
        {
            var vendor = await service.GetVendorById(id);
            return View(vendor);
        }

        


        public async Task<IActionResult> Selections()
        {
            var data = await service.GetVendorSelections();

            return View(data);
        }

        public async Task<IActionResult> SelectionDetails(int id)
        {
            var selection = await service.GetVendorSelectionById(id);

            return View(selection);
        }

        [HttpPost]
        public async Task<IActionResult> SelectVendor(VendorSelection selection)
        {
            if (!ModelState.IsValid)
            {
                return View(selection);
            }

            await service.AddVendorSelection(selection);

            return RedirectToAction("Selections");
        }
    }
}




