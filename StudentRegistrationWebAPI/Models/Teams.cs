using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }

    }
}
