namespace MyApp.Dto
{
    public class GetBasketDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }


    }

    public class GetBasketByUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<GetGiftDto> gifts { get; set; }

    }

    public class CreateBasketDto
    {
        public int UserId { get; set; }
    }

    public class AddGiftToBasketDto
    {
        public int BasketId { get; set; }
        public int GiftId { get; set; }
    }

    public class DeleteGiftFromBasketDto { 
        public int BasketId { get; set; }
        public int GiftId { get; set; }
    }
    
}
