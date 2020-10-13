using System.Collections.Generic;
using System.Net;
using ChatAPI.Controllers;
using DataAccessLayer;
using Xunit;


namespace ChatAPITest
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
            var testProd=new DataModel.ProductDataModel()
            {
                ProductName = "IntelliVue X3",
                Id = 0,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
        }
        [Fact]
        public void TestRemoveMethod()
        {
            var testProd = new DataModel.ProductDataModel()
            {
                ProductName = "IntelliVue X3",
                Id = 0,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
            Assert.True(_productController.RemoveProduct(testProd)==HttpStatusCode.OK);
        }
        [Fact]
        public void TestUpdateMethod()
        {
            var testProd = new DataModel.ProductDataModel()
            {
                ProductName = "IntelliVue X3",
                Id = 0,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productController.AddProduct(testProd)==HttpStatusCode.OK);
            testProd.Portable = false;
            Assert.True(_productController.UpdateProduct(testProd)==HttpStatusCode.OK);
        }

    }
}
