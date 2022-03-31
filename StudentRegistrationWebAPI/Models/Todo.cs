using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationWebAPI.Models
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        [Required]
        public string TodoName { get; set; }

        public int UserId { get; set; }

        public bool Checked { get; set;}

        [NotMapped]
        public string Username { get; set; }

    }
}
