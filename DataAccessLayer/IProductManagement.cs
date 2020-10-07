using DataModel;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IProductManagement
    {
        bool AddProduct(ProductDataModel product);
        bool RemoveProduct(ProductDataModel product);
        IEnumerable<ProductDataModel> ShowAllProducts();
        bool UpdateProduct(ProductDataModel product);
    }
}
