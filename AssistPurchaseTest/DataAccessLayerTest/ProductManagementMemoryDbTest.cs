using System.Linq;
using System.Net;
using System.Security.Cryptography;
using DataAccessLayer;
using AssistPurchaseTest.Util;
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
        public void TestValidProductDataAddition()
        {
            var num = RandomNumberGenerator.GetInt32(100) + 10;
            var testProd = Helper.GetProductDataModelObject(num,"Test"+num);
            Assert.True(_productManagement.AddProduct(testProd)==HttpStatusCode.OK);
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
        public void TestRemoveProduct()
        {
            var num = RandomNumberGenerator.GetInt32(100) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "test"+num);
            //Case 1
            _productManagement.AddProduct(testProd);
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.OK);
            //Case 2
            testProd= new ProductDataModel();
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var num = RandomNumberGenerator.GetInt32(100) + 10;
            var testProd = Helper.GetProductDataModelObject(num, "test"+num);
            //Case 1
            _productManagement.AddProduct(testProd);
            testProd.Portable = false;
            Assert.True(_productManagement.UpdateProduct(testProd) == HttpStatusCode.OK);
            //Case 1-Clean Up
            _productManagement.RemoveProduct(testProd);

            //Case 2
            testProd = new ProductDataModel();
            Assert.True(_productManagement.UpdateProduct(testProd)== HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestShowAllProducts()
        {
            var productList = _productManagement.GetAllProducts();
            Assert.True(productList.Any());
        }

        
    }
}
