using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataAccessLayer;
using DataModel;
using Xunit;

namespace AssistPurchaseTest.DataAccessLayerTest
{
    
    public class ProductManagementMemoryDbTest
    {
        private readonly IProductManagement _productManagement;

        public ProductManagementMemoryDbTest()
        {
            _productManagement=new ProductManagementMemoryDb();
        }
        [Fact]
        public void TestAddProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 104,
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
            Assert.True(_productManagement.AddProduct(testProd)==HttpStatusCode.OK);
            testProd=new ProductDataModel();
            Assert.True(_productManagement.AddProduct(testProd)==HttpStatusCode.BadRequest);

        }
        [Fact]
        public void TestRemoveProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 101,
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
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.OK);
            testProd=new ProductDataModel
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
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 101,
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
            Assert.True(_productManagement.UpdateProduct(testProd)== HttpStatusCode.OK);
            testProd = new ProductDataModel {
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
            Assert.True(_productManagement.UpdateProduct(testProd)== HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestShowAllProducts()
        {
            var productList = _productManagement.GetAllProducts();
            Assert.True(productList.Any());
        }

        [Fact]
        public void TestToStringData()
        {
            var testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = 104,
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
            Assert.False(string.IsNullOrEmpty(testProd.ToString()));
            testProd = new ProductDataModel
            {
                ProductName = "",
                Id = 104,
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
            Assert.True(string.IsNullOrEmpty(testProd.ProductName));

        }
    }
}
