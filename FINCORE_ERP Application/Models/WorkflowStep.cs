using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class WorkflowStep
    {
        [Key]
        public int workflow_step_id { get; set; }

        public int? workflow_definition_id { get; set; }

        public WorkflowDefinition? WorkflowDefinition { get; set; }

        public int step_number { get; set; }

        public string step_name { get; set; }

        public int? approver_role_id { get; set; }

        public Role? ApproverRole { get; set; }

        public bool is_mandatory { get; set; } = true;

        public bool can_reject { get; set; } = true;

        public bool is_active { get; set; } = true;

        public DateTime created_at { get; set; } = DateTime.Now;

        public int? created_by { get; set; }

        public DateTime? modified_at { get; set; } = DateTime.Now;

        public int? modified_by { get; set; }

        public User User { get; set; }
    }
}