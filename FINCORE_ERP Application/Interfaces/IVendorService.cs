using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IVendorService
    {
               
            Task<Vendor> AddVendor(Vendor v);
            Task<List<Vendor>> GetVendor();
            Task<Vendor> GetVendorById(int id);
            Task UpdateVendor(Vendor v);
            Task DelVendor(int id);

            Task<List<VendorCategory>> GetVendorCategories();
            Task<VendorCategory> GetVendorCategoryById(int id);
            Task AddVendorCategory(VendorCategory category);
            Task UpdateVendorCategory(VendorCategory category);
            Task DeleteVendorCategory(int id);

            Task UpdatePerformanceScore(int vendorId, decimal score);
            Task UpdateVerification(int vendorId, byte verified);
            Task UpdateStatus(int vendorId, byte status);

            Task<List<VendorSelection>> GetVendorSelections();
            Task<VendorSelection> GetVendorSelectionById(int id);
            Task AddVendorSelection(VendorSelection selection);
        
    }
}


        