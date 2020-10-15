using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "Test"+num);
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.OK);
            //Clean Up
            _productManagement.RemoveProduct(testProd);

        }
        [Fact]
        public void TestInvalidProductDataAddition()
        {
            var testProd = new ProductDataModel();
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestValidProductDataRemove()
        {
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "Test"+num);
            _productManagement.AddProduct(testProd);
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.OK);
        }

        [Fact]
        public void TestInvalidProductDataRemove()
        {
            var testProd = Helper.GetProductDataModelObject(-999, "Test42");
            Assert.True(_productManagement.RemoveProduct(testProd) == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestProductDataUpdate()
        {
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
            var productList = _productManagement.GetAllProducts();
            Assert.True(productList.Any());
        }

    }
}
