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
                ProductPrice = 1000000,
                ProductWeight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
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
                ProductPrice = 2000000,
                ProductWeight = 2000,
                Portable = true,
                MonitorResolution = "1024*920",
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
                ProductPrice = 3000000,
                ProductWeight = 3000,
                Portable = false,
                MonitorResolution = "1024*1020",
                Measurement = new List<string>()
            });
        }
        public bool AddProduct(DataModel.ProductDataModel product, ITransactionManager manager)
        {
            try
            {
                product.Id = 0;
                if (string.IsNullOrEmpty(product.ProductName))
                    return false;
                manager.GetTransaction();
                product.Id = GenerateProductId();
                Db.Add(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static int GenerateProductId()
        {
            var max = Db[0].Id;
            max = Db.Select(product => product.Id).Prepend(max).Max();

            return max + 1;
        }
        public bool RemoveProduct(DataModel.ProductDataModel product, ITransactionManager manager)
        {
            try
            {
                manager.GetTransaction();
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

        public IEnumerable<DataModel.ProductDataModel> GetAllProducts(ITransactionManager manager)
        {
            manager.GetTransaction();
            return Db;
        }

        public bool UpdateProduct(DataModel.ProductDataModel product, ITransactionManager manager)
        {
            manager.GetTransaction();
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
