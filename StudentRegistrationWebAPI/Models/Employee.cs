using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public string EmployeeGender { get; set; }

        [Required]
        public string EmployeeDOB { get; set; }

        [Required]
        public int EmployeeTeam { get; set; }

        [Required]
        public string EmployeeManager { get; set; }

        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Phone { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }

        public string About { get; set; }

        public int UserId { get; set; }

    }
}
