using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataAccessLayer;
using DataModel;
using Xunit;
namespace AssistPurchaseTest.DataAccessLayerTest
{
    public class ProjectManagementSqLiteTest
    {
        
        private readonly IProductManagement _productManagement;

        public ProjectManagementSqLiteTest()
        {
            _productManagement = new ProjectManagementSqLite();
        }
        [Fact]
        public void TestAddProduct()
        {
            var testProd = new ProductDataModel
            {
                ProductName = "IntelliVue MX1000",
                Id = 104,
                ProductSeries = "Intellivue",
                ProductModel = "MX1000",
                ScreenSize = 15,
                Weight = 1400,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.OK);
            testProd = new ProductDataModel();
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.InternalServerError);

        }
        [Fact]
        public void TestRemoveProduct()
        {
            var testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = 1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ScreenSize = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.OK);
            testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = -1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ScreenSize = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = 1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ScreenSize = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.UpdateProduct(testProd) == HttpStatusCode.OK);
            testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = -1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ScreenSize = 1000000,
                Weight = 1000,
                Portable = false,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.UpdateProduct(testProd) == HttpStatusCode.InternalServerError);
        }
        [Fact]
        public void TestShowAllProducts()
        {
            var productList = _productManagement.GetAllProducts();
            Assert.True(productList.Any());
        }

    }
}
