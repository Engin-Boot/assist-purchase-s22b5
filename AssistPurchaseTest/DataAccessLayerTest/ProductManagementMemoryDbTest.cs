using System.Linq;
using System.Net;
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
        public void TestValidDataAddition()
        {
            var testProd = Helper.GetProductDataModelObject(10,"Test10");
            Assert.True(_productManagement.AddProduct(testProd)==HttpStatusCode.OK);
        }
        [Fact]
        public void TestInvalidDataAddition()
        {
            var testProd = new ProductDataModel();
            Assert.True(_productManagement.AddProduct(testProd) == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestRemoveProduct()
        {
            var testProd = Helper.GetProductDataModelObject(11, "test11");
            _productManagement.AddProduct(testProd);
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.OK);
            
            testProd= new ProductDataModel();
            Assert.True(_productManagement.RemoveProduct(testProd)==HttpStatusCode.BadRequest);
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var testProd = Helper.GetProductDataModelObject(12, "test12");
            _productManagement.AddProduct(testProd);
            testProd.Portable = false;
            Assert.True(_productManagement.UpdateProduct(testProd) == HttpStatusCode.OK);
            
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
