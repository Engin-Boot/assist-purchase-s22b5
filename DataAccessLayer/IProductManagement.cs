using System.Collections.Generic;
using DataAccessLayer.Utils;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        bool AddProduct(DataModel.ProductDataModel product, ITransactionManager manager);
        bool RemoveProduct(DataModel.ProductDataModel product, ITransactionManager manager);
        IEnumerable<DataModel.ProductDataModel> GetAllProducts(ITransactionManager manager);
        bool UpdateProduct(DataModel.ProductDataModel product, ITransactionManager manager);
    }
}
