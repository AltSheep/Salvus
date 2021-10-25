using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Salvus.Models;

namespace Salvus.Dtos
{
    public class AssetDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string CoinId { get; set; }

        [Required]
        public float Ammount { get; set; }
    }
}