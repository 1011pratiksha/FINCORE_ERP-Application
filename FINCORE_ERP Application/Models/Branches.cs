using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Branches
    {
        [Key]
        public int branch_id { get; set; }

       [ ForeignKey("company_id")]
        public int? company_id { get; set; }
        public Company Companies { get; set; }

        public int branch_code { get; set; }
        public string branch_name { get; set; }

        //address add kiya hai kyon ki proper addres sirf state country and city se nhi decide ho sakto toh yeh 
        //bhi required rhega
        public string address { get; set; } 

        public string country { get; set; }
        public string state { get; set; }

        public string city { get; set; }
        public byte is_active { get; set; }

        public DateTime created_at { get; set; }

         [ForeignKey("user_id")]
        public int? created_by { get; set; }
          public User User { get; set; }

        public DateTime? modified_at { get; set; }

         [ForeignKey("user_id")]
        public int? modified_by { get; set; }

        //navigation property
        public List<Department> Departments { get; set; }


    }
}
