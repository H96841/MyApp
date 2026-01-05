using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Winner
    {
        public int Id { get; set; }

        [Required]
        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime winningDate { get; set; }


    }
}
