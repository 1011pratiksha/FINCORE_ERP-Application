using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class ApprovalLog
    {
        [Key]
        public int approval_log_id { get; set; }

        [ForeignKey("workflow_definition_id")]
        public int workflow_definition_id { get; set; }
        public WorkflowDefinition? WorkflowDefinition { get; set; }
  
        public string entity_name { get; set; }

        public int entity_id { get; set; }


        [ForeignKey("workflow_step_id")]
        public int workflow_step_id { get; set; }

        public WorkflowStep? WorkflowStep { get; set; }


        [ForeignKey("approver_user_id")]
        public int approver_user_id { get; set; }

        public User? ApproverUser { get; set; }

        public string action { get; set; }

        public string? comments { get; set; }

        public DateTime action_date { get; set; } = DateTime.Now;

        public string status { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;

        [ForeignKey("user_id")]
        public int created_by { get; set; }

        public DateTime modified_at { get; set; } = DateTime.Now;

        [ForeignKey("user_id")]
        public int modified_by { get; set; }

        public User User { get; set; }


    }
}
