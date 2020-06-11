using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Stream
    {
        public int Id { get; }

        [Required]
        [MaxLength(4000)]
        public string Link { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
