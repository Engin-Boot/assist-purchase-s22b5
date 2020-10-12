using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataModel;

namespace ChatAPI.Utils
{
    public class FilterUtil
    {
        private readonly IProductManagement _productDb;
        private readonly TransactionUtil _serviceProvider;

        public FilterUtil(IProductManagement productDb, IServiceProvider serviceProvider)
        {
            _productDb = productDb;
            _serviceProvider = new TransactionUtil(serviceProvider);
        }

        public IEnumerable<ProductDataModel> ProductFilter(Filter filtersList)
        {
            var products = _productDb.GetAllProducts(_serviceProvider.GeTransactionObjectFromContainer());

            var filteredProducts = new List<ProductDataModel>();

            if (!string.IsNullOrEmpty(filtersList.IsPortable))
            {
                var searchCriteria = bool.Parse(filtersList.IsPortable);
                filteredProducts.AddRange(products.Where(product => product.Portable == searchCriteria));
            }

            if (!(filtersList.MinWeight <= 0 || filtersList.MaxWeight <= filtersList.MinWeight))
            {
                filteredProducts = FilterByWeight(filtersList.MinWeight, filtersList.MaxWeight, filteredProducts);
            }

            if (!(filtersList.MinScreenSize <= 0 || filtersList.MaxScreenSize <= filtersList.MinScreenSize))
            {
                filteredProducts =
                    FilterByScreenSize(filtersList.MinScreenSize, filtersList.MaxScreenSize, filteredProducts);
            }

            if (!(filtersList.Measurements.Equals(null)))
            {
                filteredProducts = FilterByMeasurements(filtersList.Measurements, filteredProducts);
            }

            return filteredProducts;
        }

        private List<ProductDataModel> FilterByMeasurements(List<string> filtersList, List<ProductDataModel> productList)
        {
            var filteredProducts = new List<ProductDataModel>();
            foreach (var product in from product in productList let match = filtersList.All(measurement => product.Measurement.Contains(measurement)) where match select product)
            {
                filteredProducts.Add(product);
            }

            return filteredProducts;
        }

        private static List<ProductDataModel> FilterByWeight(double minWeight, double maxWeight,
            IEnumerable<ProductDataModel> productList)
        {
            return productList.Where(product => product.Weight >= minWeight && product.Weight <= maxWeight).ToList();
        }

        private static List<ProductDataModel> FilterByScreenSize(double minScreenSize, double maxScreenSize,
            IEnumerable<ProductDataModel> productList)
        {
            return productList.Where(product => product.ScreenSize >= minScreenSize && product.ScreenSize <= maxScreenSize).ToList();
        }

        


    }
}
