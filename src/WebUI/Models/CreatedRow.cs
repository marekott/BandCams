using System.Text.Json.Serialization;

namespace WebUI.Models
{
    public class CreatedRow
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
