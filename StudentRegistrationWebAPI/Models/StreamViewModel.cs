using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationWebAPI.Models
{
    public class StreamViewModel
    {
        [Key]
        public int StreamId { get; set; }
        [Required]
        public string StreamName { get; set; }

    }
}
