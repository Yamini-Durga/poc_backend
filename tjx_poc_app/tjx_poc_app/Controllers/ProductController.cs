using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tjx_poc_app.Interfaces;
using tjx_poc_app.Models;

namespace tjx_poc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProductController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{code}")]
        public ActionResult<IEnumerable<Product>> GetAllProducts(string code)
        {
            var products = _repo.GetProductsByCode(code);
            return Ok(products);
        }
        [HttpGet("codes")]
        public ActionResult<IEnumerable<CurrencyCode>> GetAllCurrencyCodes()
        {
            var codes = _repo.GetCurrencyCodes();
            return Ok(codes);
        }
    }
}
