using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Salvus.Models;

namespace Salvus.Dtos
{
    public class UpdateAssetDto
    {
        [JsonPropertyName("symbol")]
        [Required]
        public string Symbol { get; set; }
        
        [JsonPropertyName("ammount")]
        [Required]
        public float Ammount { get; set; }
    }
}