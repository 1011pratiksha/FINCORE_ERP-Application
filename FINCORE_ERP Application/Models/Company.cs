using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Company
    {
        [Key]
        public int company_id { get; set; }

        public string company_Code { get; set; }

        public string company_name { get; set; }

        public string legal_name { get; set; }

        public string tax_number { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string country { get; set; }

        public string GSTIN { get; set; }

        public string CIN { get; set; }

        public string PAN { get; set; }

        public string TAN { get; set; }

        public byte is_active { get; set; }

        public DateTime created_at { get; set; }

        public int? created_by { get; set; }

        public User User { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }

        //navigation property
        public List<Branches> Branches { get; set; }
    }
}