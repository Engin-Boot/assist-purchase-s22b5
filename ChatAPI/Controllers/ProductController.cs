using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConflictResult = System.Web.Http.Results.ConflictResult;

namespace ChatAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _product;
        public ProductController(IProductManagement product)
        {
            _product = product;
           
        }
        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(500);
                //    return Ok(_product.GetAllProducts());
            }
            catch
            {

                return StatusCode(500);
            }
            
        }
        [HttpPost]
        public HttpStatusCode AddProduct([FromBody ] ProductDataModel product)
        {
            
            return _product.AddProduct(product);
        }

        [HttpPut]
        public bool UpdateProduct([FromBody] ProductDataModel product)
        {
            return _product.UpdateProduct(product);
        }

        [HttpDelete]
        public HttpStatusCode RemoveProduct([FromBody] ProductDataModel product)
        {
            return _product.RemoveProduct(product);
        }
    }
    
}
