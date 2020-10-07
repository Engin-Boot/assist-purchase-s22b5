using System.Linq;
using DataAccessLayer;
using DataModel;
using Xunit;
namespace DataAccessLayerTest
{
    public class ProductManagementMemoryDbTest
    {
        //private static readonly List<ProductDataModel> _testDb=new List<ProductDataModel>();
        private readonly IProductManagement _productManagement;

        public ProductManagementMemoryDbTest()
        {
            _productManagement=new ProductManagementMemoryDb();
        }
        [Fact]
        public void TestAddProduct()
        {
            var testProd = new ProductDataModel {Id = "id3"};
            Assert.True(_productManagement.AddProduct(testProd));
            testProd=new ProductDataModel();
            Assert.False(_productManagement.AddProduct(testProd));
        }
        [Fact]
        public void TestRemoveProduct()
        {
            var testProd = new ProductDataModel { Id = "id1" };
            Assert.True(_productManagement.RemoveProduct(testProd));
            testProd=new ProductDataModel{Id="RandomId"};
            Assert.False(_productManagement.RemoveProduct(testProd));
        }
        [Fact]
        public void TestUpdateProduct()
        {
            var testProd = new ProductDataModel { Id = "id1" };
            Assert.True(_productManagement.UpdateProduct(testProd));
            testProd = new ProductDataModel { Id = "RandomId" };
            Assert.False(_productManagement.UpdateProduct(testProd));
        }
        [Fact]
        public void TestShowAllProducts()
        {
            var productList = _productManagement.ShowAllProducts();
            Assert.True(productList.Any());
        }
    }
}
