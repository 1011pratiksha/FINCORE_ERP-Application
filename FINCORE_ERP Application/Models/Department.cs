using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Department
    {
        [Key]
        public int department_id { get; set; }

        public int? branch_id { get; set; }

        public Branches Branch { get; set; }

        public string department_name { get; set; }

        public string department_code { get; set; }

        public byte is_active { get; set; }

        public int? created_by { get; set; }

        public DateTime created_at { get; set; }

        public int? modified_by { get; set; }

        public User User { get; set; }

        public DateTime? modified_at { get; set; }
    }
}