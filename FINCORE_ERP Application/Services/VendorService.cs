using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using FINCORE_ERP_Application.Data;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{

    public class VendorService : IVendorService
    {
        ApplicationDbContext db;

        public VendorService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Vendor> AddVendor(Vendor v)
        {
            await db.Vendors.AddAsync(v);
            await db.SaveChangesAsync();

            return v;
        }

        public async Task<List<Vendor>> getVendor()
        {
            var data = await db.Vendors.ToListAsync();
            return data;
        }

        public async Task<Vendor> getVendorById(int id)
        {
            var data = await db.Vendors.FindAsync(id);
            return data;
        }

        public async Task UpdateVendor(Vendor v)
        {
            var data = await db.Vendors.FindAsync(v.VendorId);
            db.Vendors.Update(data);
            await db.SaveChangesAsync();
        }

        public async Task DelVendor(int id)
        {
            var data = await db.Vendors.FindAsync(id);
            db.Vendors.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<VendorCategory>> GetVendorCategories()
        {
            return await db.VendorCategories
                .Where(x => x.IsActive == 1)
                .ToListAsync();
        }

        public async Task<VendorCategory> GetVendorCategoryById(int id)
        {
            return await db.VendorCategories
                .FirstOrDefaultAsync(x => x.VendorCategoryId == id);
        }

        public async Task AddVendorCategory(VendorCategory category)
        {
            await db.VendorCategories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        public async Task UpdateVendorCategory(VendorCategory category)
        {
            var data = await db.VendorCategories.FindAsync(category.VendorCategoryId);
            db.VendorCategories.Update(data);
            await db.SaveChangesAsync();

        }

        public async Task DeleteVendorCategory(int id)
        {
            var data = await db.VendorCategories.FindAsync(id);

            data.IsActive = 0;
            data.ModifiedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public async Task UpdatePerformanceScore(int vendorId, decimal score)
        {
            var vendor = await db.Vendors.FindAsync(vendorId);

            vendor.PerformanceScore = score;
            vendor.ModifiedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public async Task UpdateVerification(int vendorId, byte verified)
        {
            var vendor = await db.Vendors.FindAsync(vendorId);

            vendor.IsVerified = verified;
            vendor.ModifiedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public async Task UpdateStatus(int vendorId, byte status)
        {
            var vendor = await db.Vendors.FindAsync(vendorId);

            vendor.IsActive = status;
            vendor.ModifiedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public async Task<List<VendorSelection>> GetVendorSelections()
        {
            return await db.VendorSelections
                .Include(x => x.RFQ)
                .Include(x => x.Quotation)
                .Include(x => x.SelectedVendor)
                .ToListAsync();
        }

        public async Task<VendorSelection> GetVendorSelectionById(int id)
        {
            return await db.VendorSelections
                .Include(x => x.RFQ)
                .Include(x => x.Quotation)
                .Include(x => x.SelectedVendor)
                .FirstOrDefaultAsync(x => x.VendorSelectionId == id);
        }

        public async Task AddVendorSelection(VendorSelection selection)
        {
            selection.SelectedDate = DateTime.Now;

            await db.VendorSelections.AddAsync(selection);
            await db.SaveChangesAsync();
        }

        public Task<List<Vendor>> GetVendor()
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetVendorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

