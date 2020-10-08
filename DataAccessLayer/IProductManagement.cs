using DataModel;
using System.Collections.Generic;
using DataAccessLayer.Utils;

namespace DataAccessLayer
{
    public interface IProductManagement
    {
        bool AddProduct(ProductDataModel product, ITransactionManager manager);
        bool RemoveProduct(ProductDataModel product, ITransactionManager manager);
        IEnumerable<ProductDataModel> GetAllProducts(ITransactionManager manager);
        bool UpdateProduct(ProductDataModel product, ITransactionManager manager);
    }
}
