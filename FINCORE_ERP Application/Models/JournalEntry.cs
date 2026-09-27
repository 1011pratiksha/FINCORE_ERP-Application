using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required(ErrorMessage = "Journal Number is required")]
        [StringLength(50)]
        public string JournalNumber { get; set; }

        [Required(ErrorMessage = "Entry Date is required")]
        public DateTime EntryDate { get; set; }

        [Required]
        [ForeignKey("AccountMaster")]
        public int AccountId { get; set; }
        public AccountMaster AccountMaster { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string Description { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}