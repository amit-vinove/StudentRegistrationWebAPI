using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }

        //Foreign key for Course Defined in Form DB
        public ICollection<Student> FormData { get; set; }


    }
}
