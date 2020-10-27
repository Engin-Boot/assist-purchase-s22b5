using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using DataAccessLayer;
using DataModel;
using AssistPurchaseTest.Util;
using Xunit;
namespace AssistPurchaseTest.DataAccessLayerTest
{
    public class ProductManagementSqLiteTest
    {
        
        private readonly IProductManagement _productManagement;

        public ProductManagementSqLiteTest()
        {
            _productManagement = new ProductManagementSqLite();
            
        }
        [Fact]
        public void TestValidProductDataAddition()
        {
            Thread.Sleep(100);
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "Test"+num);
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.OK);
            //Clean Up
            _productManagement.RemoveProduct(testProd);

        }
        [Fact]
        public void TestInvalidProductDataAddition()
        {
            Thread.Sleep(100);
            var testProd = new ProductInfo();
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestValidProductDataRemove()
        {
            Thread.Sleep(200);
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "Test"+num);
            _productManagement.AddProduct(testProd);
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.OK);
        }

        [Fact]
        public void TestInvalidProductDataRemove()
        {
            Thread.Sleep(300);
            var testProd = Helper.GetProductDataModelObject(-999, "Test42");
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestProductDataUpdate()
        {
            Thread.Sleep(400);
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "Test"+num);
            _productManagement.AddProduct(testProd);
            testProd.Portable = false;
            Assert.True(_productManagement.UpdateProduct(testProd) == HttpStatusCode.OK);

            //Clean Up
            _productManagement.RemoveProduct(testProd);
        }

        [Fact]
        public void TestShowAllProducts()
        {
            Thread.Sleep(500);
            var productList = _productManagement.GetAllProducts();
            Assert.True(productList.Any());
        }
        [Fact]
        public void TestProductData()
        {
            Thread.Sleep(100);
            ProductInfo testProductDataModel = new ProductInfo
            {
                ProductName = "productName",
                Id = 1,
                ProductSeries = "Intellivue",
                ProductModel = "X33",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = "SPO2,ECG"
            };
            Assert.Equal("productName", testProductDataModel.ProductName);
            Assert.Equal(1, testProductDataModel.Id);
            Assert.Equal("Intellivue", testProductDataModel.ProductSeries);
            Assert.Equal("X33", testProductDataModel.ProductModel);
            Assert.Equal(1000, testProductDataModel.Weight);
            Assert.True(testProductDataModel.Portable);
            Assert.Equal("1024*720", testProductDataModel.MonitorResolution);
            Assert.Equal(5, testProductDataModel.ScreenSize);
            Assert.Equal("SPO2,ECG", testProductDataModel.Measurement);
        }
    }
}
