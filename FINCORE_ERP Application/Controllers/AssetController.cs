using FINCORE_ERP_Application.Interface;
using FINCORE_ERP_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE_ERP_Application.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetAssignmentService assignmentService;
        private readonly IAssetDepreciationService depreciationService;
        private readonly IAssetDisposalService disposalService;
        private readonly IAssetHistoryService historyService;
        private readonly IAssetLocationService locationService;
        private readonly IAssetService assetService;


        public AssetController(IAssetAssignmentService assignmentService, IAssetDepreciationService depreciationService, IAssetDisposalService disposalService, IAssetHistoryService historyService, IAssetLocationService locationService, IAssetService assetService)
        {
            this.assignmentService = assignmentService;
            this.depreciationService = depreciationService;
            this.disposalService = disposalService;
            this.historyService = historyService;
            this.locationService = locationService;
            this.assetService = assetService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await assetService.GetAllAsync();
            return View(data);
        }

        public IActionResult AddA()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddA(Asset a)
        {
            await assetService.AddAsync(a);
            TempData["Smsg"] = "Asset Added Successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DelA(int id)
        {
            await assetService.DeleteAsync(id);
            TempData["Dmsg"] = "Asset Deleted Successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateA(int id)
        {
            var data = await assetService.GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateA(Asset a)
        {
            await assetService.UpdateAsync(a);
            TempData["Umsg"] = "Asset Updated Successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await assetService.GetByIdAsync(id);
            return View(data);
        }
    }
}
