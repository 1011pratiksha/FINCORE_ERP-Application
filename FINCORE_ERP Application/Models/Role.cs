using System.ComponentModel.DataAnnotations;

namespace FINCORE_ERP_Application.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }

        public string role_name { get; set; }

        public string? description { get; set; }

        public byte isActive { get; set; }

        public int created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }


        public List<Permission> Permissions { get; set; }


    }
}
