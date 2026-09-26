using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public int CountryCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CountryName { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        // Navigation Properties
        public List<Company> Companies { get; set; }
        public List<State> States { get; set; }
    }
}
