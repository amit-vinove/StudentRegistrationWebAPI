using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        [Required]
        public string TodoName { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool Checked { get; set;}

    }
}
