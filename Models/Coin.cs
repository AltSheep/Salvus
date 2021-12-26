using System;
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

        [JsonPropertyName("price")]
        [Required]
        public float Price { get; set; }

        [JsonPropertyName("marketcap")]
        [Required]
        public Int64 Marketcap { get; set; }

        [JsonPropertyName("volume")]
        [Required]
        public Int64 Volume { get; set; }

        [JsonPropertyName("high")]
        [Required]
        public float High { get; set; }

        [JsonPropertyName("1d")]
        [Required]
        public float DayChange { get; set; }

        [JsonPropertyName("7d")]
        [Required]
        public float WeekChange { get; set; }



        
    }
}