using FINCORE_ERP_Application.Models;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FINCORE_ERP_Application.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [ForeignKey("role_id")]
        public int role_id { get; set; }
        public Role role { get; set; }

        public string full_name { get; set; }

        public string email { get; set; }

        public string pass { get; set; }

        public string phone { get; set; }

        public byte is_active { get; set; }


        [ForeignKey("user_id")]
        public int created_by { get; set; }
         public User user { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }


         [ForeignKey("user_id")]
        public int? modified_by { get; set; }



    }
}


