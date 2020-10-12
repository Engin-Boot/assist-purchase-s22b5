using System;
using System.Collections.Generic;
using DataModel;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/chatapp")]
    [ApiController]
    public class ChatAppController : ControllerBase
    {
        private readonly FilterUtil _filter;
        

        public ChatAppController(DataAccessLayer.IProductManagement productDb, IServiceProvider serviceProvider)
        {
            _filter = new FilterUtil(productDb, serviceProvider);
           
        }

        // GET: api/chat-app
        [HttpGet]
        public IEnumerable<ProductDataModel> FilterProducts([FromQuery] Filter filtersList)
        {
            return _filter.ProductFilter(filtersList);
        }
        

         // POST: api/ChatApp
         [HttpPost]
         public void Post()
         {
            
         }
    }
}
