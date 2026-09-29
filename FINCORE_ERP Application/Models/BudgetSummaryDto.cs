using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class BudgetSummaryDto
    {
        public int BudgetId { get; set; }

        public string BudgetCode { get; set; } = string.Empty;


        public string BudgetName { get; set; } = string.Empty;


        public string FinancialYear { get; set; } = string.Empty;


        public decimal BudgetAmount { get; set; } 

        public decimal  TotalUtilized {  get; set; }

        public decimal TotalVariance => BudgetAmount - TotalUtilized;

        public List<LineItemSummary> Lines { get; set; } = new();

        public class LineItemSummary
        {
            public int BudgetLineId { get; set; }
            public decimal AllocatedAmount { get; set; }

            public string CategoryName { get; set; } = string.Empty;

            public decimal UtilizedAmount { get; set; }

            public decimal VarianceAmount => AllocatedAmount - UtilizedAmount;
        }


    }
}
