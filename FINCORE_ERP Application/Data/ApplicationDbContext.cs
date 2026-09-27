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

        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        public DbSet<BudgetLine> BudgetLines { get; set; }

        public DbSet<Budget> Budgets { get; set;  }

        public DbSet<ExpenseClaim> ExpenseClaims { get; set; }

        public DbSet<OpexRequest> OpexRequests { get; set; } 

        public DbSet<CapexRequest> CapexRequests { get; set; }

        public DbSet<AccountMaster> AccountMaster { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<ARInvoice> ARInvoices { get; set; }
        public DbSet<RevenueEntry> RevenueEntries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AssetAssignment> AssetAssignments { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }
        public DbSet<AssetDepreciation> AssetDepreciations { get; set; }
        public DbSet<AssetDisposal> AssetDisposals { get; set; }
        public DbSet<AssetHistory> AssetHistories { get; set; }

    }
}

