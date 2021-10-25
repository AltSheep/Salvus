using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Salvus.Models
{
    public class Coin
    {
        [JsonPropertyName("id")]
        [Key]
        public string Id { get; set; }
        
        [JsonPropertyName("symbol")]
        [Required]
        public string Symbol { get; set; }
        
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}