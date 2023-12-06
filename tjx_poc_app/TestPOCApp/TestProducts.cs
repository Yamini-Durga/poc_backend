using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using tjx_poc_app.Data;
using tjx_poc_app.Interfaces;
using tjx_poc_app.Models;

namespace TestPOCApp
{
    [TestClass]
    public class TestProducts
    {
        Mock<ProductContext> context;
        IRepository _repo;
        List<Product> products;
        [TestInitialize]
        public void TestInitialize()
        {
            products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Test",
                    Description = "Test",
                    Price = 100
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Test2",
                    Description = "Test2",
                    Price = 120
                }
            };

            var dbOptions = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase("poc")
                .Options;

            ProductContext context = new ProductContext(dbOptions);
            context.Products.AddRange(products);
            context.SaveChanges();
            _repo = new Repository(context);

        }
        [TestMethod]
        public void TestGetAllProducts()
        {
            var result = _repo.GetProductsByCode("INR");

            Assert.AreEqual(result.ToList().Count, 2);
        }
    }
}