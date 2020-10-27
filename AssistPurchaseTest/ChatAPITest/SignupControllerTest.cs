using AssistPurchaseTest.Util;
using ChatAPI.Controllers;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;

namespace AssistPurchaseTest.ChatAPITest
{
    public class SignupControllerTest
    {
        private readonly SignupController _signupController;
        public SignupControllerTest()
        {
            ISignup user = new SignupImpl();
            _signupController = new SignupController(user);
        }
        [Fact]
        public void TestValidDataAddition()
        {
            Thread.Sleep(100);
            UserData userData = new UserData
            {
                Email = "abcd1234@gmail.com",
                Password = "abcd@4321",
                RepeatPassword = "abcd@4321"
            };
            Assert.True(_signupController.AddUser(userData) == HttpStatusCode.OK);
           
        }
        [Fact]
        public void TestValidUser()
        {
            Thread.Sleep(100);
            UserData userData = new UserData
            {
                Email = "abcd1234@gmail.com",
                Password = "abcd@4321",
                RepeatPassword = "abcd@4321"
            };
            var res = _signupController.Validate(userData);
            Assert.NotNull(res);
            Assert.IsType<string>(res);
        }
    }
}
