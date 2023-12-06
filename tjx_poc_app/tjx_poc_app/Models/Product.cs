using System.ComponentModel.DataAnnotations;

namespace tjx_poc_app.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        public double Price { get; set; }
    }
}
