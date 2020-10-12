using System;
using System.Collections.Generic;
using ChatAPI.Utils;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/product"), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _product;
        private readonly TransactionUtil _service;
        public ProductController(IProductManagement product,IServiceProvider service)
        {
            _product = product;
            _service = new TransactionUtil(service);
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductDataModel> Get()
        {
            return _product.GetAllProducts(_service.GeTransactionObjectFromContainer());
        }
        [HttpPost]
        public bool AddProduct([FromBody ] ProductDataModel product)
        {
            
            return _product.AddProduct(product, _service.GeTransactionObjectFromContainer());
        }

        [HttpPut]
        public bool UpdateProduct([FromBody] ProductDataModel product)
        {
            return _product.UpdateProduct(product, _service.GeTransactionObjectFromContainer());
        }

        [HttpDelete]
        public bool RemoveProduct([FromBody] ProductDataModel product)
        {
            return _product.RemoveProduct(product, _service.GeTransactionObjectFromContainer());
        }
    }
    
}
