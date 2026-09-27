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



    }
}

