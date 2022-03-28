using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }

        [Required]
        public string EmployeeTeam { get; set; }

        [Required]
        public string Designation { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
