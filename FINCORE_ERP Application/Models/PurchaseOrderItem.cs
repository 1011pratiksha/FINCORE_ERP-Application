using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int POItemId { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; }

        public byte IsActive { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required]
        public int QuotationItemId { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }
    }
}