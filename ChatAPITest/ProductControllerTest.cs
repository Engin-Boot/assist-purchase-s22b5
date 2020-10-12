using System;
using System.Linq;
using ChatAPI.Controllers;
using ChatAPI.Utils;
using DataAccessLayer;
using DataAccessLayer.Utils;
using Moq;
using Xunit;


namespace ChatAPITest
{
    public class ProductControllerTest
    {

        private readonly IProductManagement _product;
        private Mock<IServiceProvider> _service;
        public ProductControllerTest()
        {
            _product=new ProductManagementMemoryDb();
            _service = new Mock<IServiceProvider>();
            

        }
        [Fact]
        public void TestGetMethod()
        {
            var productController = new ProductController(_product, _service.Object);
            var list = productController.Get();
            Assert.True(list.Any());
        }
    }
}
