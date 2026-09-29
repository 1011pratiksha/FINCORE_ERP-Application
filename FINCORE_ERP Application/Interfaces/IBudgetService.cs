using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IBudgetService
    {
        Task createBudget(Budget b);

        Task<List<Company>> GetCompaniesAsync();

        Task<List<Department>> GetDepartmentsAsync();

        Task<List<BudgetCategory>> GetBudgetCategoriesAsync();

        Task<List<Budget>> fetchBudgets();

        Task EditBudgets(Budget b);

        Task<Budget?> GetBudgetByIdAsync(int id);

        Task ApproveBudgetAsync(int BudgetId, int approvedByUserId);

        Task RejectBudgetAsync(int BudgetId);



        Task<BudgetSummaryDto?> GetBudgetTrackingAndVariance(int BudgetId);


    }
}
