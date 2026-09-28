using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace FINCORE_ERP_Application.Models
{
    public class RolePermissionModule
    {
        [Key]
        public int role_permission_module_id { get; set; }

        public int? role_id { get; set; }

        public Role role { get; set; }

        public int? permission_id { get; set; }

        public Permissions permissions { get; set; }

        public int? module_id { get; set; }

        public Module module { get; set; }

        public int? created_by { get; set; }

        public DateTime created_at { get; set; }

        public int? modified_by { get; set; }

        public User User { get; set; }

        public DateTime? modified_at { get; set; }
    }
}