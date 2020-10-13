using System.Collections.Generic;
using System.Net;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        HttpStatusCode AddProduct(DataModel.ProductDataModel product);
        HttpStatusCode RemoveProduct(DataModel.ProductDataModel product);
        IEnumerable<DataModel.ProductDataModel> GetAllProducts();
        HttpStatusCode UpdateProduct(DataModel.ProductDataModel product);
    }
}
