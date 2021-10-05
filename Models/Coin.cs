using System.ComponentModel.DataAnnotations;

namespace Salvus.Models
{
    public class Coin
    {
        [Key]
        [StringLength(32)]
        public string id { get; set; }
        [Required]
        [StringLength(32)]
        public string symbol { get; set; }
        [Required]
        [StringLength(64)]
        public string name { get; set; }
    }
}