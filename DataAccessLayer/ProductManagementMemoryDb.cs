using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;

namespace DataAccessLayer
{
    public class ProductManagementMemoryDb:IProductManagement
    {
        private static readonly List<ProductDataModel> Db=new List<ProductDataModel>();

        public ProductManagementMemoryDb()
        {
            Db.Add(new ProductDataModel{Id = "id1"});
            Db.Add(new ProductDataModel{ Id = "id2" });
        }
        public bool AddProduct(ProductDataModel product)
        {
            try
            {
                if (!string.IsNullOrEmpty(product.Id))
                {
                    Db.Add(product);
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }

            return false;
        }

        public bool RemoveProduct(ProductDataModel product)
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

        public IEnumerable<ProductDataModel> ShowAllProducts()
        {
            return Db;
        }

        public bool UpdateProduct(ProductDataModel product)
        {
            try
            {
                for (var index = 0; index < Db.Count; index++)
                {
                    if (Db[index].Id != product.Id) continue;
                    Db.RemoveAt(index);
                    Db.Insert(index,product);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
