using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class BudgetService : IBudgetService
    {
        ApplicationDbContext db;

        public BudgetService(ApplicationDbContext db)
        {
            this.db = db;
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
            return await db.Budgets.ToListAsync();
        }
    }
}
