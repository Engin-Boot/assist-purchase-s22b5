using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataModel;

namespace DataAccessLayer
{
    public class ProductManagementMemoryDb:IProductManagement
    {
        private static readonly List<ProductInfo> Db=new List<ProductInfo>();

        public ProductManagementMemoryDb()
        {
            Db.Add(new ProductInfo
            { 
                ProductName = "IntelliVue X3",
                Id = 101,
                ProductSeries = "Intellivue", 
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = "SPO2,ECG"
                
            });
            Db.Add(new ProductInfo
            {
                ProductName = "IntelliVue MX40",
                Id = 102,
                ProductSeries = "Intellivue",
                ProductModel = "MX40",
                Weight = 2000,
                Portable = true,
                MonitorResolution = "1024*920",
                ScreenSize = 15,
                Measurement = "SPO2"
                
            });

            Db.Add(new ProductInfo
            {
                ProductName = "IntelliVue MX750",
                Id = 103,
                ProductSeries = "Intellivue",
                ProductModel = "MX750",
                Weight = 3000,
                Portable = false,
                MonitorResolution = "1024*1020",
                ScreenSize = 29,
                Measurement =""
            });
        }
        public HttpStatusCode AddProduct(ProductInfo product)
        {
            product.Id = 0;
                if (string.IsNullOrEmpty(product.ProductName))
                    return HttpStatusCode.BadRequest;

            product.Id = GenerateProductId();
            Db.Add(product);
            return HttpStatusCode.OK;
        }

        private static int GenerateProductId()
        {
            var max = Db[0].Id;
            max = Db.Select(product => product.Id).Prepend(max).Max();

            return max + 1;
        }
        public HttpStatusCode RemoveProduct(int id)
        {
            
            foreach (var products in Db.Where(products => products.Id == id))
            {
                Db.Remove(products);
                return HttpStatusCode.OK;
            }
            
            return HttpStatusCode.BadRequest;
        }

        public IEnumerable<ProductInfo> GetAllProducts()
        {
          
            return Db;
        }

        public HttpStatusCode UpdateProduct(ProductInfo product)
        {
            for (var index = 0; index < Db.Count; index++) 
            {
                    if (Db[index].Id != product.Id) continue;
                    Db.RemoveAt(index);
                    Db.Insert(index,product);
                    return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        

        
    }
}
