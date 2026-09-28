using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class ProfitCenter
    {
        [Key]
        public int profit_center_id { get; set; }

        public string profit_center_name { get; set; }

        public int? company_id { get; set; }

        public Company company { get; set; }

        public string? profit_center_description { get; set; }

        public byte is_active { get; set; }

        public int? created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }

        public User user { get; set; }
    }
}