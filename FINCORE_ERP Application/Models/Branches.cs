using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Branches
    {
        [Key]
        public int BranchId { get; set; }

       [ ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Companies { get; set; }

        public int BranchCode { get; set; }
        public string BranchName { get; set; }

        //address add kiya hai kyon ki proper addres sirf state country and city se nhi decide ho sakto toh yeh 
        //bhi required rhega
        public string Address { get; set; } 

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
        public string City { get; set; }

        [ForeignKey("CityId")]
        public City Cities { get; set; }
        public byte IsActive { get; set; }

        public DateTime created_at { get; set; }

        // ForeignKey[("UserId")]
        public int created_by { get; set; }
        //  public User User { get; set; }

        public DateTime? modified_at { get; set; }

        // ForeignKey[("UserId")]
        public int? modified_by { get; set; }




    }
}
