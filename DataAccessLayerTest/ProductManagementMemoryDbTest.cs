using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Utils;
using DataModel;
using Xunit;
namespace DataAccessLayerTest
{
    public class ProductManagementMemoryDbTest
    {
        //private static readonly List<ProductDataModel> _testDb=new List<ProductDataModel>();
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
                Id = "id1",
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
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
                Id = "id1",
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.RemoveProduct(testProd, _transactionManager));
            testProd=new ProductDataModel{
                ProductName = "IntelliVue X3",
                Id = "RandomId",
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
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
                Id = "id1",
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(_productManagement.UpdateProduct(testProd, _transactionManager));
            testProd = new ProductDataModel {
                ProductName = "IntelliVue X3",
                Id = "randomId",
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
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
            var productList = _productManagement.ShowAllProducts(_transactionManager);
            Assert.True(productList.Any());
        }
    }
}
