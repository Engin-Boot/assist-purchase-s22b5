using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Utils;
using Xunit;
using DataModel;
namespace DataAccessLayerTest
{
    
    public class ProductManagementMemoryDbTest
    {
        private readonly IProductManagement _productManagement;
        private readonly ITransactionManager _transactionManager;

        public ProductManagementMemoryDbTest()
        {
            _productManagement=new ProductManagementMemoryDb();
            _transactionManager=new TransactionManager();
        }
        [Fact]
        public void TestAddProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 104,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Price = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.AddProduct(testProd, _transactionManager));
            testProd=new ProductDataModel();
            Assert.False(_productManagement.AddProduct(testProd, _transactionManager));
        }
        [Fact]
        public void TestRemoveProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 101,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Price = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.RemoveProduct(testProd, _transactionManager));
            testProd=new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = -1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Price = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.False(_productManagement.RemoveProduct(testProd, _transactionManager));
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = 101,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Price = 1000000,
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.UpdateProduct(testProd, _transactionManager));
            testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = -1,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Price = 1000000,
                Weight = 1000,
                Portable = false,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.False(_productManagement.UpdateProduct(testProd, _transactionManager));
        }
        [Fact]
        public void TestShowAllProducts()
        {
            var productList = _productManagement.GetAllProducts(_transactionManager);
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
                Price = 1000000,
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
                Price = 1000000,
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
