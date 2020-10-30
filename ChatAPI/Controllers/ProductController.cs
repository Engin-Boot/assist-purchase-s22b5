using System;
using System.Net;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ChatAPI.Controllers
{
    [EnableCors()]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _product;
        public ProductController(IProductManagement product)
        {
            _product = product;

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_product.GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpPost]
        public HttpStatusCode AddProduct([FromBody] ProductInfo product)
        {
            return _product.AddProduct(product);
        }

        [HttpPut]
        public HttpStatusCode UpdateProduct([FromBody] ProductInfo product)
        {
            return _product.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public HttpStatusCode RemoveProduct(int id)
        {
            return _product.RemoveProduct(id);
        }
    }
    
}
