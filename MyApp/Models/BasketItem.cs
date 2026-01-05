namespace MyApp.Models
{
    public class BasketItem
    {
        public int Id { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }


        public int GiftId { get; set; }
        public Gift Gift { get; set; }


        public int Quantity { get; set; }
    }
}
