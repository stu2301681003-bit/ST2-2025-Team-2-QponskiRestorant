using System.ComponentModel.DataAnnotations;

namespace JapaneseRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Range(1, 20)]
        public int PeopleCount { get; set; }
        
    }
}
