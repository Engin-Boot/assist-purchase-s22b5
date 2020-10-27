using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestedCustomerController : ControllerBase
    {
        IInterestedCustomer _interestedCustomer;
        public InterestedCustomerController(IInterestedCustomer repo)
        {
            _interestedCustomer = repo;
        }
        // GET: api/<InterestedCustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_interestedCustomer.GetAllInterestedCustomers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // POST api/<InterestedCustomerController>
        [HttpPost]
        public HttpStatusCode AddCustomer([FromBody] DataModel.CustomerDetails value)
        {
            return _interestedCustomer.InterestedCustomer(value);
        }

    }
}
