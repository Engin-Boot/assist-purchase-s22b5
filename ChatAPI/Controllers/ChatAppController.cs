using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Utils;
using DataModel;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
        [HttpGet(template:"filter-by-price/{minPrice}/{maxPrice}")]
        public IEnumerable<ProductDataModel> Get(double minPrice, double maxPrice, [FromBody] IEnumerable<ProductDataModel> productList)
        {
            

            /*Filters.FilterByPrice(minPrice, maxPrice, productList);
            return products.Where(product => product.ProductPrice >= minPrice && product.ProductPrice <= maxPrice).ToList();*/
            return null;
            //return _productDb.GetAllProducts(GeTransactionObjectFromContainer());
        }
        //[HttpGet("FilterByPrice")]
        //public IEnumerable<string> FilterByPrivce()
        //{
        //    return new[] { "value3", "valu4" };
        //}

        /* // GET: api/ChatApp/5
         [HttpGet("{id}", Name = "Get")]
         public string Get(int id)
         {
             return "value";
         }

         // POST: api/ChatApp
         [HttpPost]
         public void Post([FromBody] string value)
         {
         }

         // PUT: api/ChatApp/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE: api/ApiWithActions/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/

       

    }
}
