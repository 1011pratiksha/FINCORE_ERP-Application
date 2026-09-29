using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }

        public Company Company { get; set; }

        [ForeignKey("department")]
        public int DepartmentId { get; set; }

        public Department department { get; set; }

        [Required]
        [StringLength(20)]
        public string BudgetCode { get; set; }

        [Required]
        [StringLength(20)]
        public string BudgetName { get; set; }

        [Required]
        [StringLength(20)]
        public string FinancialYear { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BudgetAmount { get; set; }

        [Required]
        public byte IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }

        public User ModifiedByUser { get; set; }

        [ForeignKey("ApprovedByUser")]
        public int? ApprovedBy { get; set; }
        public User ApprovedByUser { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public List<BudgetLine> BudgetLines { get; set; }

    }
}
