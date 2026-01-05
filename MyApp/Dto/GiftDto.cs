using MyApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Dto
{
    public class GetGiftDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        //public Category Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        
        //public Donor Donor { get; set; }
    }

    public class CreateGiftDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int DonorId { get; set; }


    }
    public class UpdateGiftDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int DonorId { get; set; }
        
    }

}
