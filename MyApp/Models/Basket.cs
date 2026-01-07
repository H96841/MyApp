using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Basket
    {
        public int Id { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Gift")]
        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public int Quantity { get; set; }
    }
}