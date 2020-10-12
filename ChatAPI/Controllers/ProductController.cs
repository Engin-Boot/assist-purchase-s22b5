using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Utils;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAPI.Controllers
{
    [Route("api/product"), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _product;
        private readonly IServiceProvider _service;
        public ProductController(IProductManagement product,IServiceProvider service)
        {
            _product = product;
            _service = service;
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductDataModel> Get()
        {
            Console.WriteLine(_product.GetAllProducts(GeTransactionObjectFromContainer()));
            return _product.GetAllProducts(GeTransactionObjectFromContainer());
        }
        [HttpPost]
        public bool AddProduct([FromBody ] ProductDataModel product)
        {
            
            return _product.AddProduct(product, GeTransactionObjectFromContainer());
        }

        [HttpPut]
        public bool UpdateProduct([FromBody] ProductDataModel product)
        {
            return _product.UpdateProduct(product, GeTransactionObjectFromContainer());
        }

        [HttpDelete]
        public bool RemoveProduct([FromBody] ProductDataModel product)
        {
            return _product.RemoveProduct(product, GeTransactionObjectFromContainer());
        }

        private ITransactionManager GeTransactionObjectFromContainer()
        {
            return _service.GetService<ITransactionManager>();
        }
    }
    
}
