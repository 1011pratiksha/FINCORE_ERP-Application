using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FINCORE_ERP_Application.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentNumber { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [StringLength(20)]
        public string PaymentType { get; set; }

        [ForeignKey("APInvoice")]
        public int? APInvoiceId { get; set; }
        public APInvoice APInvoice { get; set; }

        [ForeignKey("ARInvoice")]
        public int? ARInvoiceId { get; set; }
        public ARInvoice ARInvoice { get; set; }

        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        [StringLength(20)]
        public string PaymentMethod { get; set; }

        [ForeignKey("ApprovedByUser")]
        public int? ApprovedBy { get; set; }
        public User ApprovedByUser { get; set; }

        public bool ReconciledFlag { get; set; }

        [Required(ErrorMessage = "Approval status is required")]
        [StringLength(20)]
        public string ApprovalStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}