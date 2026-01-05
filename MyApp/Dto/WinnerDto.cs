using MyApp.Models;

namespace MyApp.Dto
{
    public class    GetWinnerDto
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public int UserId { get; set; }
        public DateTime winningDate { get; set; }
    }

       public class CreateWinnerDto
    {
        public int GiftId { get; set; }
        public int UserId { get; set; } 

    }


}
