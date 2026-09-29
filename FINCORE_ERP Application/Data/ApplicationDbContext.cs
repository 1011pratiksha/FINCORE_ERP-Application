using Microsoft.EntityFrameworkCore;
using FINCORE_ERP_Application.Models;



namespace FINCORE_ERP_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApprovalLog> ApprovalLog { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<ProfitCenter> ProfitCenter { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePermissionModule> RolePermissionModule { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WorkflowDefinition> WorkflowDefinition { get; set; }
        public DbSet<WorkflowHistory> WorkflowHistory { get; set; }
        public DbSet<WorkflowStep> WorkflowStep { get; set; }


        public DbSet<RFQVendor> RFQVendors { get; set; }
        public DbSet<RFQ> RFQs { get; set; } 
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<VendorSelection> VendorSelections { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<PurchaseRequisitionItem> PurchaseRequisitionItems { get; set; }
        public DbSet<VendorCategory> VendorCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<APInvoice> APInvoices { get; set; }
        public DbSet<AccountMaster> AccountMasters { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<ARInvoice> ARInvoices { get; set; }
        public DbSet<RevenueEntry> RevenueEntries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AssetAssignment> AssetAssignments { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }
        public DbSet<AssetDepreciation> AssetDepreciations { get; set; }
        public DbSet<AssetDisposal> AssetDisposals { get; set; }
        public DbSet<AssetHistory> AssetHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One CAPEX request can be linked with multiple assets
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.CapexRequest)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CapexRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // One vendor can provide multiple assets
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Vendor)
                .WithMany(v => v.Assets)
                .HasForeignKey(a => a.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One department can have multiple assets
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Department) 

                .WithMany(d => d.Assets)
                .HasForeignKey(a => a.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Keep track of all assignments made for an asset
            modelBuilder.Entity<AssetAssignment>()
                .HasOne(aa => aa.Asset)
                .WithMany(a => a.AssetAssignments)
                .HasForeignKey(aa => aa.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // An employee can be assigned multiple assets
            modelBuilder.Entity<AssetAssignment>()
                .HasOne(aa => aa.Employee)
                .WithMany()
                .HasForeignKey(aa => aa.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Store the different locations of an asset
            modelBuilder.Entity<AssetLocation>()
                .HasOne(al => al.Asset)
                .WithMany(a => a.AssetLocations)
                .HasForeignKey(al => al.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // An asset can have multiple depreciation records
            modelBuilder.Entity<AssetDepreciation>()
                .HasOne(ad => ad.Asset)
                .WithMany(a => a.AssetDepreciations)
                .HasForeignKey(ad => ad.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // An asset can have multiple disposal records as per the current model
            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.Asset)
                .WithMany(a => a.AssetDisposals)
                .HasForeignKey(ad => ad.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Store the history of changes made to an asset
            modelBuilder.Entity<AssetHistory>()
                .HasOne(ah => ah.Asset)
                .WithMany(a => a.AssetHistories)
                .HasForeignKey(ah => ah.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Store which user performed an asset history action
            modelBuilder.Entity<AssetHistory>()
                .HasOne(ah => ah.PerformedByUser)
                .WithMany()
                .HasForeignKey(ah => ah.PerformedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // A user can be linked with multiple customers
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // A company can have multiple customers
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // A customer can have multiple revenue entries
            modelBuilder.Entity<RevenueEntry>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.RevenueEntries)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // A department can have multiple revenue entries
            modelBuilder.Entity<RevenueEntry>()
                .HasOne(r => r.Department)
                .WithMany()
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // One account can be used for multiple revenue entries
            modelBuilder.Entity<RevenueEntry>()
                .HasOne(r => r.AccountMaster)
                .WithMany()
                .HasForeignKey(r => r.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Store the user who created the revenue entry
            modelBuilder.Entity<RevenueEntry>()
                .HasOne(r => r.CreatedByUser)
                .WithMany()
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Store the user who last modified the revenue entry
            modelBuilder.Entity<RevenueEntry>()
                .HasOne(r => r.ModifiedByUser)
                .WithMany()
                .HasForeignKey(r => r.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // A customer can have multiple AR invoices
            modelBuilder.Entity<ARInvoice>()
                .HasOne(ar => ar.Customer)
                .WithMany(c => c.ARInvoices)
                .HasForeignKey(ar => ar.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // A revenue entry can be linked with multiple AR invoices
            modelBuilder.Entity<ARInvoice>()
                .HasOne(ar => ar.RevenueEntry)
                .WithMany(r => r.ARInvoices)
                .HasForeignKey(ar => ar.RevenueEntryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

