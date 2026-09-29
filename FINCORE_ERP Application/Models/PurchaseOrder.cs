using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int QuotationId { get; set; }

        [Required]
        [StringLength(30)]
        public string PONumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        public byte IsActive { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        public User CreatedByUser { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public User ModifiedByUser { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public List<PurchaseOrderItem> PurchaseOrderItems { get; set; }
            = new List<PurchaseOrderItem>();
    }
}