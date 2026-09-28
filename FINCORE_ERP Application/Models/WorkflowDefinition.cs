using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class WorkflowDefinition
    {
        [Key]
        public int workflow_definition_id { get; set; }

        public string workflow_name { get; set; }

        public string module_name { get; set; }

        public string entity_name { get; set; }

        public string? description { get; set; }

        public bool is_active { get; set; } = true;

        public DateTime created_at { get; set; } = DateTime.Now;

        [ForeignKey("user_id")]
        public int? created_by { get; set; }

        public DateTime? updated_at { get; set; }

        [ForeignKey("user_id")]
        public int? updated_by { get; set; }
        public User User { get; set; }


        // Navigation Property
        public ICollection<WorkflowStep>? WorkflowSteps { get; set; }
    }
}
