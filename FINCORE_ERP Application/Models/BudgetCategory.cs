using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class BudgetCategory
    {
        [Key]
        public int BudgetCategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

        public string CategoryCode { get; set; }

        public string Description { get; set; }


        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }

        // Navigation Properties
        public List<BudgetLine> BudgetLines { get; set; }
    }
}
