using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseRestaurant.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int DishId { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; }

        public int Quantity { get; set; }
    }
}
