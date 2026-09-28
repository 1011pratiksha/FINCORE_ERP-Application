using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }

        public string employee_name { get; set; }

        public int? user_id { get; set; }
        public User user { get; set; }

        public int? department_id { get; set; }
        public Department department { get; set; }

        public int? designation_id { get; set; }
        public Role designation { get; set; }

        public int? company_id { get; set; }
        public Company company { get; set; }

        public DateTime? joining_date { get; set; }

        public byte is_active { get; set; }

        public int created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }

        [Column("Reporting Manager")]
        public int? reporting_manager_id { get; set; }

        public Employee reporting_manager { get; set; }

        List<Employee> subordinates { get; set; }
    }
}