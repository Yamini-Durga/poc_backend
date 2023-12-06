using Microsoft.EntityFrameworkCore;
using tjx_poc_app.Models;

namespace tjx_poc_app.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
            
        }
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
    }
}
