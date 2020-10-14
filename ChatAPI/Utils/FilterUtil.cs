using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataModel;

namespace ChatAPI.Utils
{
    public class FilterUtil
    {
        private readonly IProductManagement _productDb;

        public FilterUtil(IProductManagement productDb )
        {
            _productDb = productDb;
        }

        public IEnumerable<ProductDataModel> ProductFilter(Filter filtersList)
        {
            var products = _productDb.GetAllProducts();

            var filteredProducts = FilterByPortability(filtersList.IsPortable, products);

            filteredProducts = FilterByMeasurements(filtersList.Measurements, filteredProducts);

            filteredProducts = FilterByWeight(filtersList.MinWeight, filtersList.MaxWeight, filteredProducts);

            filteredProducts = FilterByScreenSize(filtersList.MinScreenSize, filtersList.MaxScreenSize, filteredProducts);

            return filteredProducts;
        }

        private static IEnumerable<ProductDataModel> FilterByPortability(string isPortable, IEnumerable<ProductDataModel> productList)
        {
            if (string.IsNullOrEmpty(isPortable)) return productList;
            
            var searchCriteria = bool.Parse(isPortable);

            var filteredList = new List<ProductDataModel>();

            foreach (var product in productList)
            {
                if (product.Portable == searchCriteria)
                {
                    filteredList.Add(product);
                }
            }
            return filteredList;  
        }
        private static IEnumerable<ProductDataModel> FilterByMeasurements(List<string> measurements, IEnumerable<ProductDataModel> productList)
        {
            if (measurements == null) return productList;

            var filteredList = new List<ProductDataModel>();
            foreach (var product in productList)
            {
                var match = true;
                foreach (var measurement in measurements)
                {
                    if (product.Measurement.Contains(measurement))continue;
                    match = false;
                    break;
                }

                if (match)
                {
                    filteredList.Add(product);
                }
            }
            return filteredList;
        }

        private static IEnumerable<ProductDataModel> FilterByWeight(double minWeight, double maxWeight,
            IEnumerable<ProductDataModel> productList)
        {
            if (minWeight < 0 || maxWeight <= minWeight) return productList;
            
            var filteredList = new List<ProductDataModel>();
            
            foreach (var product in productList)
            {
                if (product.Weight >= minWeight && product.Weight <= maxWeight)
                {
                    filteredList.Add(product);
                }
            }
            return filteredList;
        }

        private static IEnumerable<ProductDataModel> FilterByScreenSize(double minScreenSize, double maxScreenSize,
            IEnumerable<ProductDataModel> productList)
        {
            if (minScreenSize <= 0 || maxScreenSize <= minScreenSize) return productList;
            
            var filteredList = new List<ProductDataModel>();
            
            foreach (var product in productList)
            {
                if (product.ScreenSize >= minScreenSize && product.ScreenSize <= maxScreenSize)
                {
                    filteredList.Add(product);
                }
            }

            return filteredList;
        }

        


    }
}
