namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone {  get; set; }
       
        
        public List<Purchase> Purchases { get; set; }=new List<Purchase>();
        public List<Basket> Baskets { get; set; }=new List<Basket>();
        public List<Winner> Winner { get; set; } = new List<Winner>();
        

    }
}
