using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }

    }
}
