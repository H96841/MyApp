namespace MyApp.Dto
{
    public class GetPurchaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal PriceTicket { get; set; }
        public DateTime PurchaseDate { get; set; }

    }

    public class CreatPurchaseDto
    {
       public int UserId { get; set; }
        public decimal PriceTicket { get; set; }
        public List<int> GiftsId { get; set; } = new List<int>();   
        public DateTime PurchaseDate { get; set; }

    }
}
