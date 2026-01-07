using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyApp.Models
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]  
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    
        // Navigation property required by EF and by your repository Include(...)
        public Category Category { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; } = null!;

        [AllowNull]
        [ForeignKey("Winner")]
        public int? WinnerId { get; set; }
        public Winner Winner { get; set; } = null!;


    }
}
