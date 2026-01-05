using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Gift> Gifts { get; set; } = new List<Gift>();
    }
}
