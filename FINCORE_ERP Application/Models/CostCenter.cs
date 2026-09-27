using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class CostCenter
    {
        [Key]
        public int cost_center_id { get; set; }

        [ForeignKey("company_id")]
        public int? company_id { get; set; }
        public Company company { get; set; }

        [ForeignKey("department_id")]
        public int? department_id { get; set; }
        public Department department { get; set; }


        public string cost_center_name { get; set; }

        public string? cost_center_description { get; set; }

        public byte is_active { get; set; }

        [ForeignKey("user_id")]
        public int? created_by { get; set; }


        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }


        [ForeignKey("user_id")]
        public int? modified_by { get; set; }
        public User User { get; set; }
    }
}
