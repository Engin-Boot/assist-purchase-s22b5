using AssistPurchaseTest.Util;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;

namespace AssistPurchaseTest.DataAccessLayerTest
{
    public class SignupImplTest
    {
        private readonly ISignup _signup;

        public SignupImplTest()
        {
            _signup = new SignupImpl();
        }


        [Fact]
        public void TestValidProductDataAddition()
        {
            Thread.Sleep(100);
            UserData userData = new UserData
            {
                Email = "abcd1234@gmail.com",
                Password = "abcd@4321",
                RepeatPassword = "abcd@4321"
            };
            Assert.True(_signup.RegisterUser(userData) == HttpStatusCode.OK);
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
            var res = _signup.ValidateUser(userData);
            Assert.IsType<bool>(res);
            Assert.True(res);
        }
    }
}
