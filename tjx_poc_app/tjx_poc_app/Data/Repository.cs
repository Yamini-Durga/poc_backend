using Microsoft.EntityFrameworkCore;
using tjx_poc_app.Interfaces;
using tjx_poc_app.Models;

namespace tjx_poc_app.Data
{
    public class Repository : IRepository
    {
        private readonly ProductContext _dbContext;

        public Repository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CurrencyCode> GetCurrencyCodes()
        {
            return _dbContext.CurrencyCodes.ToList();
        }

        public IEnumerable<Product> GetProductsByCode(string code)
        {
            var products = new List<Product>();
            if(code == null || code == "INR")
            {
                products = _dbContext.Products.ToList();
            }
            else
            {
                var codeRecord = _dbContext.CurrencyCodes
                    .FirstOrDefaultAsync(r => r.Currencycode == code).Result;
                if(codeRecord != null)
                {
                    products = _dbContext.Products.ToList();
                    foreach(var product in products)
                    {
                        product.Price = Math.Round(product.Price / codeRecord.ExhchangeRate, 2);
                    }
                }
            }
            return products;
        }
    }
}
