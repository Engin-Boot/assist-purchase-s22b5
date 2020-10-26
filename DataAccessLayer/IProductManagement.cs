using System.Collections.Generic;
using System.Net;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        HttpStatusCode AddProduct(DataModel.ProductInfo product);
        HttpStatusCode RemoveProduct(DataModel.ProductInfo product);
        IEnumerable<DataModel.ProductInfo> GetAllProducts();
        HttpStatusCode UpdateProduct(DataModel.ProductInfo product);
    }
}
