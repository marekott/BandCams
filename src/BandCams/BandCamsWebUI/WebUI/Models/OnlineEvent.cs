using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebUI.Models
{
    public class OnlineEvent
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Nazwa zespołu / Artysty / Wydarzenia")]
        [Required(ErrorMessage = "Pole Nazwa zespołu / Artysty / Wydarzenia jest wymagane.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Notka")]
        [Required(ErrorMessage = "Pole Notka jest wymagane.")]
        [MaxLength(4000)]
        public string Description { get; set; }

        [JsonPropertyName("startDate")]
        [DisplayName("Start")]
        [Required(ErrorMessage = "Pole Start jest wymagane.")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("organizer")]
        [DisplayName("Organizator")]
        [Required(ErrorMessage = "Pole Organizator jest wymagane.")]
        [MaxLength(100)]
        public string Organizer { get; set; }

        public byte[] ImageContent { get; set; }
    }
}
