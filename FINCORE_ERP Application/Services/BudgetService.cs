using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly ApplicationDbContext db;

        public BudgetService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task ApproveBudgetAsync(int BudgetId, int approvedByUserId)
        {
            var budget = await db.Budgets.FindAsync(BudgetId);
            if(budget != null)
            {
                budget.ApprovedBy = approvedByUserId;
                budget.ApprovedAt = DateTime.Now;
                budget.IsActive = 1;
                budget.ModifiedBy = approvedByUserId;
                budget.ModifiedAt = DateTime.Now;

                await db.SaveChangesAsync();
                

            }
        }

        public async Task  createBudget(Budget b)
        {
            await db.Budgets.AddAsync(b);
            await db.SaveChangesAsync();
        }

        public async Task EditBudgets(Budget b)
        {
            db.Budgets.Update(b);
            await db.SaveChangesAsync();
        }

        public async Task<List<Budget>> fetchBudgets()
        {
            return await db.Budgets.Include(b => b.Company).Include(b => b.department).Include(b => b.ApprovedByUser).Include(b => b.BudgetLines).ThenInclude(bl => bl.BudgetCategory).ToListAsync();
        }

        public async Task<Budget?> GetBudgetByIdAsync(int id)
        {
            return await db.Budgets.Include(b => b.Company).Include(b => b.department).Include(b => b.ApprovedByUser).Include(b => b.BudgetLines).ThenInclude(bl => bl.BudgetCategory).FirstOrDefaultAsync(b =>b.BudgetId == id);
        }

        public async Task<List<BudgetCategory>> GetBudgetCategoriesAsync()
        {
            return await db.BudgetCategories.Where(c => c.IsActive ==1).ToListAsync();
        }

        public async Task<BudgetSummaryDto?> GetBudgetTrackingAndVariance(int BudgetId)
        {
            var budget = await db.Budgets.Include(b => b.BudgetLines).ThenInclude(bl => bl.BudgetCategory).Include(b => b.BudgetLines).ThenInclude(bl => bl.CapexRequests).Include(b => b.BudgetLines).ThenInclude(bl => bl.OpexRequests).FirstOrDefaultAsync(b => b.BudgetId == BudgetId);

            if (budget == null) return null;

            var lineSummaries = budget.BudgetLines.Select(line =>
            {
                decimal CapexTotal = line.CapexRequests?.Sum(c => c.Amount) ?? 0;
                decimal OpexTotal = line.OpexRequests?.Sum(c => c.Amount) ?? 0;

                return new BudgetSummaryDto.LineItemSummary
                {
                    BudgetLineId = line.BudgetLineId,
                    AllocatedAmount = line.AllocatedAmount,
                    CategoryName= line.BudgetCategory?.CategoryName ?? string.Empty,
                    UtilizedAmount = CapexTotal + OpexTotal
                };
            }).ToList();

            decimal TotalUtilized = lineSummaries.Sum(l => l.UtilizedAmount);
             
            var summaryDto = new BudgetSummaryDto
            {
                BudgetId = budget.BudgetId,
                BudgetCode = budget.BudgetCode,
                BudgetName = budget.BudgetName,
                FinancialYear = budget.FinancialYear,
                BudgetAmount = budget.BudgetAmount,
                TotalUtilized = TotalUtilized,
                Lines = lineSummaries
            };
            return summaryDto;
         }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await db.Company.ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await db.Department.ToListAsync();
        }

        public async Task RejectBudgetAsync(int BudgetId)
        {
           var budget= await db.Budgets.FindAsync(BudgetId);
            if (budget != null)
            {
                budget.IsActive = 0;
                budget.ModifiedAt = DateTime.Now;

                await db.SaveChangesAsync();
            }


             
            
        }
    }
}
