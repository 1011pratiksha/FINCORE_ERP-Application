using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

       
        public string CompanyCode { get; set; }

        
        public string CompanyName { get; set; }
        public string LegalName { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

       

        public string GSTIN { get; set; }
        public string CIN { get; set; }
        public string PAN { get; set; }

        public string TAN { get; set; }
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
