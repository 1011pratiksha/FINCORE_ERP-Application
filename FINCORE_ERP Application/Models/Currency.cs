using System.ComponentModel.DataAnnotations;

namespace FINCORE_ERP_Application.Models
{
    public class Currency
    {

        [Key]
        public int CurrencyId { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrencyName { get; set; }

        [StringLength(5)]
        public string Symbol { get; set; }

        // Navigation Properties
        public List<Country> Countries { get; set; }
    }
}
