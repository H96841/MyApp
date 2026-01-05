using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal PriceTicket {  get; set; }
        public List<int> GiftsId { get; set; } = new List<int>();
        public DateTime PurchaseDate {  get; set; }
    }
}
