using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAPI.Controllers
{
    [Route("api/Signup")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        ISignup signup;
        public SignupController(ISignup repo)
        {
            signup = repo;
        }

        [HttpPost("validate")]
        public string Validate([FromBody] DataModel.UserData value)
        {
           var res = signup.ValidateUser(value);
            return "valid credentials : " + res.ToString();
        }
        // POST api/<SignupController>
        [HttpPost]
        public HttpStatusCode AddUser([FromBody] DataModel.UserData value)
        {
            return signup.RegisterUser(value);
        }

    }
}
