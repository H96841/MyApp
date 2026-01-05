using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Basket
    {
        public int Id { get; set; }
        [Required]

        public int UserId { get; set; }
        public User User { get; set; }

        public List<BasketItem> Items { get; set; } = new();
    }
}