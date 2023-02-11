using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Cosmetic
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        [Required]
        public string brand { get; set; }

        [Required]
        public double price { get; set; }
    }
}
