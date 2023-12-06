using tjx_poc_app.Models;

namespace tjx_poc_app.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> GetProductsByCode(string code);
        IEnumerable<CurrencyCode> GetCurrencyCodes();
    }
}
