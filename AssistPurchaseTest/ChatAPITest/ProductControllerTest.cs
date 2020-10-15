using System.Net;
using System.Security.Cryptography;
using AssistPurchaseTest.Util;
using ChatAPI.Controllers;
using DataAccessLayer;
using Xunit;

namespace AssistPurchaseTest.ChatAPITest
{
    public class ProductControllerTest
    {
        private readonly ProductController _productController;
        public ProductControllerTest()
        {
            IProductManagement product = new ProductManagementMemoryDb();
            _productController = new ProductController(product);
        }
        [Fact]
        public void TestGetMethod()
        {
            
            var list = _productController.Get();
            
            Assert.NotNull(list);
        }
        [Fact]
        public void TestAddMethod()
        {
            var num = RandomNumberGenerator.GetInt32(100);
            var testProd = Helper.GetProductDataModelObject(num, "test" + num);
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
        }
        [Fact]
        public void TestRemoveMethod()
        {
            var num = RandomNumberGenerator.GetInt32(100);
            var testProd = Helper.GetProductDataModelObject(num, "test" + num);
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
            Assert.True(_productController.RemoveProduct(testProd)==HttpStatusCode.OK);
        }
        [Fact]
        public void TestUpdateMethod()
        {
            var num = RandomNumberGenerator.GetInt32(100);
            var testProd = Helper.GetProductDataModelObject(num, "Test" + num);
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
            testProd.Portable = false;
            Assert.True(_productController.UpdateProduct(testProd)==HttpStatusCode.OK);
        }


    }
}
