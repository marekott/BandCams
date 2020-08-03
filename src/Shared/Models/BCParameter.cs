using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    // ReSharper disable once InconsistentNaming
    public class BCParameter
    {
        public int Id { get; }

        [Required]
        [MaxLength(100)]
        public string Key { get; set; }

        [Required]
        [MaxLength(200)]
        public string Value { get; set; }
    }
}
