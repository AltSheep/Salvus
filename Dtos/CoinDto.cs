using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Salvus.Models;

namespace Salvus.Dtos
{
    public class CoinDto
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