using System;
using System.Collections.Generic;
using DataAccessLayer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAPI.Controllers
{
    [Route("api/chat-app")]
    [ApiController]
    public class ChatAppController : ControllerBase
    {
        private readonly DataAccessLayer.IProductManagement _productDb;
        private readonly IServiceProvider _serviceProvider;

        public ChatAppController(DataAccessLayer.IProductManagement productDb, IServiceProvider serviceProvider)
        {
            this._productDb = productDb;
            this._serviceProvider = serviceProvider;
        }
        // GET: api/ChatApp/filer-by-price
        [HttpGet(template:"filter-by-price/{minPrice}/{maxPrice}")]
        public IEnumerable<DataModel.ProductDataModel> Get(double minPrice, double maxPrice, [FromBody] IEnumerable<DataModel.ProductDataModel> productList)
        {
            //var products = _productDb.ShowAllProducts(GeTransactionObjectFromContainer());
            //var filteredProductList = new List<DataModel.ProductDataModel>();
            //foreach (var product in productList)
            //{
            //    if (product.ProductPrice >= minPrice && product.ProductPrice <= maxPrice)
            //    {
            //        filteredProductList.Add(new ProductDataModel()
            //        {
            //            ProductName = product.ProductName,
            //            Id = product.Id,
            //            ProductSeries = product.ProductSeries,
            //            ProductModel = product.ProductModel,
            //            ProductPrice = product.ProductPrice,
            //            ProductWeight = product.ProductWeight,
            //            MonitorResolution = product.MonitorResolution,
            //            Measurement = product.Measurement

            //        });

            //    }
            //}
            return _productDb.GetAllProducts(GeTransactionObjectFromContainer());
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

        private ITransactionManager GeTransactionObjectFromContainer()
        {
            return this._serviceProvider.GetService<ITransactionManager>();
        }

    }
}
