using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINCORE_ERP_Application.Models
{
    public class Employee

    {
        [Key]
        public int employee_id { get; set; }

        public string employee_name { get; set; }

        [ForeignKey("user_id")]
        public int user_id { get; set; }
        public User user { get; set; }

        [ForeignKey("department_id")]
        public int department_id { get; set; }
        public Department department { get; set; }

        [ForeignKey("role_id")]
        public int designation_id { get; set; }
        public Role designation { get; set; }

        [ForeignKey("company_id")]
        public int company_id { get; set; }
        public Company company { get; set; }

        public DateTime? joining_date { get; set; }


        public byte is_active { get; set; }


        [ForeignKey("user_id")]
        public int created_by { get; set; }


        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }


         [ForeignKey("user_id")]
        public int? modified_by { get; set; }

        [Column("Reporting Manager")]
        [ForeignKey("reporting_manager")]
        public int? reporting_manager_id { get; set; }
        public Employee reporting_manager { get; set; }


        List<Employee> subordinates { get; set; }










        
       
    }
}
