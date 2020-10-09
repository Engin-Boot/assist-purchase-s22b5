using System;
using System.Collections.Generic;
using DataModel;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/chat-app")]
    [ApiController]
    public class ChatAppController : ControllerBase
    {
        private readonly DataAccessLayer.IProductManagement _productDb;
        private readonly TransactionUtil _serviceProvider;

        public ChatAppController(DataAccessLayer.IProductManagement productDb, IServiceProvider serviceProvider)
        {
            _productDb = productDb;
           _serviceProvider = new TransactionUtil(serviceProvider);
        }
        // GET: api/ChatApp/filer-by-price
        [HttpGet]
        public IEnumerable<ProductDataModel> Get()
        {
            

            /*Filters.FilterByPrice(minPrice, maxPrice, productList);
            return products.Where(product => product.ProductPrice >= minPrice && product.ProductPrice <= maxPrice).ToList();*/
            return null;
            //return _productDb.GetAllProducts(GeTransactionObjectFromContainer());
        }
        

         // POST: api/ChatApp
         [HttpPost]
         public void Post([FromBody] string value)
         {
            Console.WriteLine(value+_productDb+_serviceProvider);
         }
    }
}
