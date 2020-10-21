using System;
using System.Collections.Generic;
using System.Linq;
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

        // POST api/<SignupController>
        [HttpPost]
        public void Post([FromBody] DataModel.UserData value)
        {
            signup.RegisterUser(value);
        }
    }
}
