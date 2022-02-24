using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class StudentViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        public string ProfileImagePath { get; set; }
        [Required]
        public int TwelfthMarks { get; set; }
        [Required]
        public int TenthMarks { get; set; }
        [Required]
        public string StudentBio { get; set; }
        public int CourseId { get; set; }
        public int StreamId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
