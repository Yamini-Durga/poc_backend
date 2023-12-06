using System.ComponentModel.DataAnnotations;

namespace tjx_poc_app.Models
{
    public class CurrencyCode
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string CountryCode { get; set; } = string.Empty;
        [Required]
        public string Currencycode { get; set; } = string.Empty;
        [Required]
        public double ExhchangeRate { get; set; }
    }
}
