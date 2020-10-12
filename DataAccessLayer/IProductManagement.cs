using System.Collections.Generic;
using DataAccessLayer.Utils;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        bool AddProduct(DataModel.ProductDataModel product);
        bool RemoveProduct(DataModel.ProductDataModel product);
        IEnumerable<DataModel.ProductDataModel> GetAllProducts();
        bool UpdateProduct(DataModel.ProductDataModel product);
    }
}
