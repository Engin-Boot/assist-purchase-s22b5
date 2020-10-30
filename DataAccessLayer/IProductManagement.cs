using System.Collections.Generic;
using System.Net;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        HttpStatusCode AddProduct(DataModel.ProductInfo product);
        HttpStatusCode RemoveProduct(int id);
        IEnumerable<DataModel.ProductInfo> GetAllProducts();
        HttpStatusCode UpdateProduct(DataModel.ProductInfo product);
    }
}
