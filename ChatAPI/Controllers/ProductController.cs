using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Utils;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductManagement _product;
        private IServiceProvider _service;
        public ProductController(IProductManagement product,IServiceProvider service)
        {
            _product = product;
            _service = service;
        }
        // GET: api/Product
        [HttpGet("products")]
        public IEnumerable<ProductDataModel> Get()
        {
            return _product.ShowAllProducts(GeTransactionObjectFromContainer());
        }
        private ITransactionManager GeTransactionObjectFromContainer()
        {
            return _service.GetService<ITransactionManager>();
        }
    }
    
}
