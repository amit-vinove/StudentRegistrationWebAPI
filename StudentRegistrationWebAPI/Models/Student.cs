using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationWebAPI.Models
{
    public class Student
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

        //Foreign key for Course & Stream
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StreamId { get; set; }
        public Stream Stream { get; set; }

        //Profile Image Path in DB
        [NotMapped]
        public IFormFile ProfileImageLocal { get; set; }

        [NotMapped]
        public string imgDummyPath { get; set; }

        public string ProfileImagePath { get; set; }

        [Required]
        public int TwelfthMarks { get; set; }
        [Required]
        public int TenthMarks { get; set; }
        [Required]
        public string StudentBio { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
