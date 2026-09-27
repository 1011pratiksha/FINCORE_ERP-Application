using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class AccountMaster
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(30)]
        public string AccountCode { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        [StringLength(60)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Account Type is required")]
        [StringLength(30)]
        public string AccountType { get; set; }

        [Required]
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }
        public List<RevenueEntry> RevenueEntries { get; set; } = new();
        public List<JournalEntry> JournalEntries { get; set; } = new();
    }
}
