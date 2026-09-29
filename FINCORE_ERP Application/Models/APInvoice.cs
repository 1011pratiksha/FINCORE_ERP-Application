using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FINCORE_ERP_Application.Models
{
    public class APInvoice
    {
        [Key]
        public int APInvoiceId { get; set; }

        [Required(ErrorMessage = "Invoice Number is required")]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [ForeignKey("GRN")]
        public int? GRNId { get; set; }
        public GRN GRN { get; set; }

        [ForeignKey("WorkOrder")]
        public int? WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Invoice file is required")]
        [StringLength(255)]
        public string InvoiceFile { get; set; }

        [ForeignKey("ApprovedByUser")]
        public int? ApprovedBy { get; set; }
        public User ApprovedByUser { get; set; }

        [Required]
        [StringLength(20)]
        public string ApprovalStatus { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}