using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        // Navigation property required by EF and by your repository Include(...)
        public Category Category { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int DonorId { get; set; }
        public Donor Donor { get; set; } = null!;
    }
}
