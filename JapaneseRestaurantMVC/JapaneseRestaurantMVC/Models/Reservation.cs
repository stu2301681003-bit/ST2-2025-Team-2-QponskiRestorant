using System.ComponentModel.DataAnnotations;

namespace JapaneseRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(1, 20)]
        public int PeopleCount { get; set; }
    }
}
