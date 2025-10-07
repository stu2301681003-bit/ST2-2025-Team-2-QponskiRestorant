using System.ComponentModel.DataAnnotations;

namespace QponskiRestorant.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
     
        public string Description { get; set; }

    }
}
