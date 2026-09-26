using System.ComponentModel.DataAnnotations;

namespace FINCORE_ERP_Application.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string Symbol { get; set; }

        // Navigation Properties
        public List<Country> Countries { get; set; }
    }
}
