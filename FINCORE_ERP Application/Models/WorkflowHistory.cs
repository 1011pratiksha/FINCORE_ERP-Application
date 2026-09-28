using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class WorkflowHistory
    {
        [Key]
        public int workflow_history_id { get; set; }

        public int? workflow_definition_id { get; set; }

        public WorkflowDefinition? WorkflowDefinition { get; set; }

        public string entity_name { get; set; }

        public int entity_id { get; set; }

        public int? workflow_step_id { get; set; }

        public WorkflowStep? WorkflowStep { get; set; }

        public string action { get; set; }

        public int? action_by { get; set; }

        public User? ActionUser { get; set; }

        public DateTime action_date { get; set; } = DateTime.Now;

        public string? comments { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;

        public int? created_by { get; set; }

        public DateTime? modified_at { get; set; } = DateTime.Now;

        public int? modified_by { get; set; }

        public User User { get; set; }
    }
}