using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeTeam { get; set; }

        [Required]
        public string Designation { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email{ get; set; }

    }
}
