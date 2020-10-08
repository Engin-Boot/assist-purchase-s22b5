using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Utils;
using DataModel;

namespace DataAccessLayer
{
    public class ProductManagementMemoryDb:IProductManagement
    {
        private static readonly List<ProductDataModel> Db=new List<ProductDataModel>();

        public ProductManagementMemoryDb()
        {
            Db.Add(new ProductDataModel{ 
                ProductName = "IntelliVue X3",
                Id = "id1",
                ProductSeries = "Intellivue", 
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            });
            Db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue MX40",
                Id = "id1",
                ProductSeries = "Intellivue",
                ProductModel = "MX40",
                ProductPrice = 2000000,
                ProductWeight = 2000,
                MonitorResolution = "1024*920",
                Measurement = new List<string>()
                {
                    "SPO2"
                }
            });

            Db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue MX750",
                Id = "id1",
                ProductSeries = "Intellivue",
                ProductModel = "MX750",
                ProductPrice = 3000000,
                ProductWeight = 3000,
                MonitorResolution = "1024*1020",
                Measurement = new List<string>()
            });
        }
        public bool AddProduct(ProductDataModel product, ITransactionManager manager)
        {
            try
            {
                manager.GetTransaction();
                if (IsValidProduct(product))
                {
                    Db.Add(product);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        private static bool IsValidProduct(ProductDataModel product)
        {
            return !string.IsNullOrEmpty(product.Id) && CheckIdExists(product);
        }

        private static bool CheckIdExists(ProductDataModel product)
        {
            return Db.All(products => products.Id != product.Id);
        }


        public bool RemoveProduct(ProductDataModel product, ITransactionManager manager)
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

        public IEnumerable<ProductDataModel> GetAllProducts(ITransactionManager manager)
        {
            manager.GetTransaction();
            return Db;
        }

        public bool UpdateProduct(ProductDataModel product, ITransactionManager manager)
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
