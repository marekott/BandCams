using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class CloseOldStream
    {
        [Required] 
        public DateTime? DateTimeNowUtc { get; set; }

        [Required]
        public int? OlderThanInMinutes { get; set; }
    }
}
