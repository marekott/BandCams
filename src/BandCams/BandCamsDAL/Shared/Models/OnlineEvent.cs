using System;
using System.ComponentModel.DataAnnotations;
using Shared.CustomAttributes;

namespace Shared.Models
{
    public class OnlineEvent
    {
        public int Id { get; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Organizer { get; set; }

        [Required]
        [MaximumSize(2097152)]
        public byte[] ImageContent { get; set; }
    }
}
