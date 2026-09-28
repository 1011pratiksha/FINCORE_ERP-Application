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

        //public DbSet<RFQVendor> RFQVendors { get; set; }
        //public DbSet<RFQ> RFQs { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<Quotation> Quotations { get; set; }
        //public DbSet<QuotationItem> QuotationItems { get; set; }
        //public DbSet<VendorSelection> VendorSelections { get; set; }
        //public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        //public DbSet<PurchaseRequisitionItem> PurchaseRequisitionItems { get; set; }
        //public DbSet<VendorCategory> VendorCategories { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<APInvoice> APInvoices { get; set; }
        //public DbSet<AccountMaster> AccountMasters { get; set; }
        //public DbSet<JournalEntry> JournalEntries { get; set; }

        //public DbSet<Asset> Assets { get; set; }
        //public DbSet<ARInvoice> ARInvoices { get; set; }
        //public DbSet<RevenueEntry> RevenueEntries { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<AssetAssignment> AssetAssignments { get; set; }
        //public DbSet<AssetLocation> AssetLocations { get; set; }
        //public DbSet<AssetDepreciation> AssetDepreciations { get; set; }
        //public DbSet<AssetDisposal> AssetDisposals { get; set; }
        //public DbSet<AssetHistory> AssetHistories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Ignore<RFQVendor>();
            modelBuilder.Ignore<RFQ>();
            modelBuilder.Ignore<Vendor>();
            modelBuilder.Ignore<Quotation>();
            modelBuilder.Ignore<QuotationItem>();
            modelBuilder.Ignore<VendorSelection>();
            modelBuilder.Ignore<PurchaseRequisition>();
            modelBuilder.Ignore<PurchaseRequisitionItem>();
            modelBuilder.Ignore<VendorCategory>();
            modelBuilder.Ignore<Payment>();
            modelBuilder.Ignore<APInvoice>();
            modelBuilder.Ignore<AccountMaster>();
            modelBuilder.Ignore<JournalEntry>();

            modelBuilder.Ignore<Asset>();
            modelBuilder.Ignore<ARInvoice>();
            modelBuilder.Ignore<RevenueEntry>();
            modelBuilder.Ignore<AssetAssignment>();
            modelBuilder.Ignore<AssetLocation>();
            modelBuilder.Ignore<AssetDepreciation>();
            modelBuilder.Ignore<AssetDisposal>();
            modelBuilder.Ignore<AssetHistory>();


          

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


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.user)
                .WithMany()
                .HasForeignKey(e => e.user_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.department)
                .WithMany()
                .HasForeignKey(e => e.department_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.designation)
                .WithMany()
                .HasForeignKey(e => e.designation_id)
                .HasPrincipalKey(r => r.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.company_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.reporting_manager)
                .WithMany()
                .HasForeignKey(e => e.reporting_manager_id)
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

            modelBuilder.Entity<Permissions>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(p => p.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Permissions>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Permissions>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.modified_by)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RolePermissionModule>()
                .HasOne(rpm => rpm.role)
                .WithMany()
                .HasForeignKey(rpm => rpm.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionModule>()
                .HasOne(rpm => rpm.permissions)
                .WithMany()
                .HasForeignKey(rpm => rpm.permission_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionModule>()
                .HasOne(rpm => rpm.module)
                .WithMany()
                .HasForeignKey(rpm => rpm.module_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionModule>()
                .HasOne(rpm => rpm.User)
                .WithMany()
                .HasForeignKey(rpm => rpm.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionModule>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(rpm => rpm.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApprovalLog>()
                .HasOne(a => a.WorkflowDefinition)
                .WithMany()
                .HasForeignKey(a => a.workflow_definition_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApprovalLog>()
                .HasOne(a => a.WorkflowStep)
                .WithMany()
                .HasForeignKey(a => a.workflow_step_id)
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

            modelBuilder.Entity<WorkflowDefinition>()
                .HasMany(w => w.WorkflowSteps)
                .WithOne(s => s.WorkflowDefinition)
                .HasForeignKey(s => s.workflow_definition_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowDefinition>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowDefinition>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(w => w.updated_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowStep>()
                .HasOne(s => s.WorkflowDefinition)
                .WithMany(w => w.WorkflowSteps)
                .HasForeignKey(s => s.workflow_definition_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowStep>()
                .HasOne(s => s.ApproverRole)
                .WithMany()
                .HasForeignKey(s => s.approver_role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowStep>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowStep>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.modified_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowHistory>()
                .HasOne(h => h.WorkflowDefinition)
                .WithMany()
                .HasForeignKey(h => h.workflow_definition_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowHistory>()
                .HasOne(h => h.WorkflowStep)
                .WithMany()
                .HasForeignKey(h => h.workflow_step_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowHistory>()
                .HasOne(h => h.ActionUser)
                .WithMany()
                .HasForeignKey(h => h.action_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowHistory>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowHistory>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(h => h.modified_by)
                .OnDelete(DeleteBehavior.Restrict);



            //// =========================================================
            //// DECIMAL PRECISION
            //// =========================================================

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
        }
    }
}