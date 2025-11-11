using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseRestaurant.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; } = 0;

        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    }
}
