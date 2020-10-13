using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DataModel;

namespace DataAccessLayer
{
    public class ProductManagementMemoryDb:IProductManagement
    {
        private static readonly List<DataModel.ProductDataModel> Db=new List<DataModel.ProductDataModel>();

        public ProductManagementMemoryDb()
        {
            Db.Add(new DataModel.ProductDataModel
            { 
                ProductName = "IntelliVue X3",
                Id = 101,
                ProductSeries = "Intellivue", 
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            });
            Db.Add(new DataModel.ProductDataModel
            {
                ProductName = "IntelliVue MX40",
                Id = 102,
                ProductSeries = "Intellivue",
                ProductModel = "MX40",
                Weight = 2000,
                Portable = true,
                MonitorResolution = "1024*920",
                ScreenSize = 15,
                Measurement = new List<string>()
                {
                    "SPO2"
                }
            });

            Db.Add(new DataModel.ProductDataModel
            {
                ProductName = "IntelliVue MX750",
                Id = 103,
                ProductSeries = "Intellivue",
                ProductModel = "MX750",
                Weight = 3000,
                Portable = false,
                MonitorResolution = "1024*1020",
                ScreenSize = 29,
                Measurement = new List<string>()
            });
        }
        public HttpStatusCode AddProduct(DataModel.ProductDataModel product)
        {

            try
            {
                product.Id = 0;
                if (string.IsNullOrEmpty(product.ProductName))
                    return HttpStatusCode.BadRequest;

                product.Id = GenerateProductId();
                Db.Add(product);
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
            
        }

        private static int GenerateProductId()
        {
            var max = Db[0].Id;
            max = Db.Select(product => product.Id).Prepend(max).Max();

            return max + 1;
        }
        public HttpStatusCode RemoveProduct(DataModel.ProductDataModel product)
        {
            try
            {
            
                foreach (var products in Db.Where(products => products.Id == product.Id))
                {
                    Db.Remove(products);
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.BadRequest;
        }

        public IEnumerable<ProductDataModel> GetAllProducts()
        {
          
            return Db;
        }

        public bool UpdateProduct(DataModel.ProductDataModel product)
        {
          //  manager.GetTransaction();
            for (var index = 0; index < Db.Count; index++) 
            {
                    if (Db[index].Id != product.Id) continue;
                    Db.RemoveAt(index);
                    Db.Insert(index,product);
                    return true;
            }
            return false;
        }
    }
}
