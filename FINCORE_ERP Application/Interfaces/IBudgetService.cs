using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IBudgetService
    {
        Task createBudget(Budget b);

        Task<List<Budget>> fetchBudgets();

        Task EditBudgets(Budget b);
    }
}
