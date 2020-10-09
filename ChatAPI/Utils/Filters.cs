using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using System.Threading.Tasks;

namespace ChatAPI.Utils
{
    public class Filters
    {
        static void FilterByPrice(double minPrice, double maxPrice, IEnumerable<ProductDataModel> productList)
        {
            IEnumerable<ProductDataModel> products;

            products = !productList.Any() ? _productDb.GetAllProducts(GeTransactionObjectFromContainer()) : productList;

        }
    }
}
