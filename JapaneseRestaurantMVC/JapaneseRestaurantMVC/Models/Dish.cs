using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseRestaurant.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, 500)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public string Recommendation { get; set; }

    }
}
