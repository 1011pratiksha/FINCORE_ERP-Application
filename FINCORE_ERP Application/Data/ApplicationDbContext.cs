using Microsoft.EntityFrameworkCore;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


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

<<<<<<< HEAD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One Vendor has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a => a.Vendor)
                .WithMany()
                .HasForeignKey(a => a.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Purchase Order has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a => a.PurchaseOrder)
                .WithMany()
                .HasForeignKey(a => a.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // One User has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a=>a.ApprovedByUser)
                .WithMany()
                .HasForeignKey(a=>a.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // One Payment has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a => a.Payments)
                .WithMany()
                .HasForeignKey(a => a.APInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // One ARInvoice has many payments
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.ARInvoice)
                .WithMany()
                .HasForeignKey(a => a.ARInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Vendor has many payments
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.Vendor)
                .WithMany()
                .HasForeignKey(a => a.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Customer has many payments
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // One User has many payments
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.ApprovedByUser)
                .WithMany()
                .HasForeignKey(a => a.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // One Account has many journal entries
            modelBuilder.Entity<JournalEntry>()
                .HasOne(a => a.AccountMaster)
                .WithMany()
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // One User has many journal entries
            modelBuilder.Entity<JournalEntry>()
                .HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

        }
=======
        public DbSet<OpexRequest> OpexRequests { get; set; }

        public DbSet<CapexRequest> CapexRequests { get; set; }

        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<BudgetLine> BudgetLines { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BudgetLine>(u =>
            {
                u.HasOne(x => x.BudgetCategory)
                .WithMany(x => x.BudgetLines)
                .HasForeignKey(x => x.BudgetCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(x => x.Budget)
                .WithMany(x => x.BudgetLines)
                .HasForeignKey(x => x.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);


            });

            builder.Entity<OpexRequest>(u =>
            {
                u.HasOne(x => x.BudgetLine)
                .WithMany(x => x.OpexRequests)
                .HasForeignKey(x => x.OpexRequestId)
                .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<CapexRequest>(u =>
            {
                u.HasOne(x => x.BudgetLine)
                .WithMany(x => x.CapexRequests)
                .HasForeignKey(x => x.CapexRequestId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }

>>>>>>> e7e661a08a8a263154421b154980f0d41f0a572c
    }
}

