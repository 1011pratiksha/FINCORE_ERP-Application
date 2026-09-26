using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionName { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte is_active { get; set; }


        public int created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }

        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public Role role { get; set; }

    }
}
