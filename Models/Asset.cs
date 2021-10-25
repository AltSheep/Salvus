using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Salvus.Models
{
    public class Asset
    {
        [JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        [Required]
        public string UserId { get; set; }
        [JsonPropertyName("user")]
        public IdentityUser User {get; set;}

        [JsonPropertyName("coinId")]
        [Required]
        public string CoinId { get; set; }
        [JsonPropertyName("coin")]
        public Coin Coin { get; set; }

        [JsonPropertyName("ammount")]
        [Required]
        public float Ammount { get; set; }
    }
}