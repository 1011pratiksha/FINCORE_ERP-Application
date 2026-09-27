using System.ComponentModel.DataAnnotations;

namespace FINCORE_ERP_Application.Models
{
    public class Module
    {
        [Key]
        public int module_id { get; set; }

        public string module_name { get; set; }

    }
}
