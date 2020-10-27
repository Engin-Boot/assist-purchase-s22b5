using AssistPurchaseTest.Util;
using ChatAPI.Controllers;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;


namespace AssistPurchaseTest.ChatAPITest
{
    public class InterestedCustomerControllerTest
    {
        private readonly InterestedCustomerController _interestedCustomerController;
        public InterestedCustomerControllerTest()
        {
            IInterestedCustomer interestedCustomer = new InterestedCustomerImpl();
            _interestedCustomerController = new InterestedCustomerController(interestedCustomer);
        }
        [Fact]
        public void TestGetMethod()
        {
            Thread.Sleep(100);
            var list = _interestedCustomerController.Get();
            Assert.NotNull(list);
        }
        [Fact]
        public void TestValidDataAddition()
        {
            Thread.Sleep(100);
            CustomerDetails customer = new CustomerDetails
            {
                ProductName = "x0",
                Email = "pranshu123@gmail.com",
                PhoneNumber = "0987654322"
            };
            Assert.True(_interestedCustomerController.AddCustomer(customer) == System.Net.HttpStatusCode.OK);
        }

       
    }
}
