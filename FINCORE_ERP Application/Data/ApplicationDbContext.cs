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
        public DbSet<ProfitCenter> ProfitCenter { get; set; }
        public DbSet<Role> Role { get; set; }
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
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
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

        public DbSet<OpexRequest> OpexRequests { get; set; }

        public DbSet<CapexRequest> CapexRequests { get; set; }

        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<BudgetLine> BudgetLines { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            

            modelBuilder.Entity<User>()
                .HasOne(u => u.role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.user)
                .WithMany()
                .HasForeignKey(u => u.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.modified_by)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Company>()
                .HasMany(c => c.Branches)
                .WithOne(b => b.Companies)
                .HasForeignKey(b => b.company_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branches>()
                .HasOne(b => b.Companies)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.company_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branches>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branches>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Branch)
                .WithMany(b => b.Departments)
                .HasForeignKey(d => d.branch_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(d => d.modified_by)
                .OnDelete(DeleteBehavior.Restrict);


           

            modelBuilder.Entity<CostCenter>()
                .HasOne(c => c.company)
                .WithMany()
                .HasForeignKey(c => c.company_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CostCenter>()
                .HasOne(c => c.department)
                .WithMany()
                .HasForeignKey(c => c.department_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CostCenter>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CostCenter>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.modified_by)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProfitCenter>()
                .HasOne(p => p.company)
                .WithMany()
                .HasForeignKey(p => p.company_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProfitCenter>()
                .HasOne(p => p.user)
                .WithMany()
                .HasForeignKey(p => p.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProfitCenter>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.role)
                .HasForeignKey(u => u.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.modified_by)
                .OnDelete(DeleteBehavior.Restrict);



          
            modelBuilder.Entity<ApprovalLog>()
                .HasOne(a => a.WorkOrder)
                .WithMany()
                .HasForeignKey(a => a.WorkOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            

            modelBuilder.Entity<ApprovalLog>()
                .HasOne(a => a.ApproverUser)
                .WithMany()
                .HasForeignKey(a => a.approver_user_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApprovalLog>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApprovalLog>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            

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
                .HasOne(a => a.ApprovedByUser)
                .WithMany()
                .HasForeignKey(a => a.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // One APInvoice has many Payments
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.APInvoice)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.APInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // One GRN has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a => a.GRN)
                .WithMany()
                .HasForeignKey(a => a.GRNId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Work Order has many APInvoices
            modelBuilder.Entity<APInvoice>()
                .HasOne(a => a.WorkOrder)
                .WithMany()
                .HasForeignKey(a => a.WorkOrderId)
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

            //decimal precision

            //modelBuilder.Entity<APInvoice>()
            //    .Property(x => x.Amount)
            //    .HasPrecision(18, 2);

            //modelBuilder.Entity<JournalEntry>()
            //    .Property(x => x.DebitAmount)
            //    .HasPrecision(18, 2);

            //modelBuilder.Entity<JournalEntry>()
            //    .Property(x => x.CreditAmount)
            //    .HasPrecision(18, 2);

            //modelBuilder.Entity<Payment>()
            //    .Property(x => x.Amount)
            //    .HasPrecision(18, 2);
            modelBuilder.Entity<BudgetLine>(u =>
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

            modelBuilder.Entity<OpexRequest>(u =>
    {
        u.HasOne(x => x.BudgetLine)
        .WithMany(x => x.OpexRequests)
        .HasForeignKey(x => x.OpexRequestId)
        .OnDelete(DeleteBehavior.Restrict);
    });


            modelBuilder.Entity<CapexRequest>(u =>
    {
        u.HasOne(x => x.BudgetLine)
        .WithMany(x => x.CapexRequests)
        .HasForeignKey(x => x.CapexRequestId)
        .OnDelete(DeleteBehavior.Restrict);
    });
}
    }
}