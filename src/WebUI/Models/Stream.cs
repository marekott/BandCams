using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebUI.Models
{
    public class Stream
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("link")]
        [Required(ErrorMessage = "Pole Link do streamingu jest wymagane.")]
        [DisplayName("Link do streamingu")]
        [RegularExpression("^.*youtube\\.com\\/watch\\?v=.*|.*facebook\\.com\\/.*videos\\/[0-9]{1,}\\/.*$", ErrorMessage = "Niepoprawny link, wprowadź link w formacie: https://www.youtube.com/watch?v=Id_Twojego_Filmu lub https://www.facebook.com/Twoja_Strona/videos/Id_Twojego_Filmu/")]
        public string Link { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }

}
