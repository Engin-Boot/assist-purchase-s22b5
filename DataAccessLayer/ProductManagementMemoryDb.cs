using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Utils;

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
                Price = 10,
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
                Price = 20,
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
                Price = 30,
                Weight = 3000,
                Portable = false,
                MonitorResolution = "1024*1020",
                ScreenSize = 29,
                Measurement = new List<string>()
            });
        }
        public bool AddProduct(DataModel.ProductDataModel product)
        {
            product.Id = 0;
            if (string.IsNullOrEmpty(product.ProductName))
                return false;
          
            product.Id = GenerateProductId();
            Db.Add(product);
            return true;
        }

        private static int GenerateProductId()
        {
            var max = Db[0].Id;
            max = Db.Select(product => product.Id).Prepend(max).Max();

            return max + 1;
        }
        public bool RemoveProduct(DataModel.ProductDataModel product)
        {
            try
            {
            
                foreach (var products in Db.Where(products => products.Id == product.Id))
                {
                    Db.Remove(products);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public IEnumerable<DataModel.ProductDataModel> GetAllProducts()
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
