using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }

        public string role_name { get; set; }

        public string? description { get; set; }

        public byte is_active { get; set; }

        [ForeignKey("user_id")]

        public int created_by { get; set; }

        public DateTime created_at { get; set; }


        [ForeignKey("user_id")]

        public int? modified_by { get; set; }
        public User User { get; set; }
        public DateTime? modified_at { get; set; }



        public List<Permissions> Permissions { get; set; }


    }
}
