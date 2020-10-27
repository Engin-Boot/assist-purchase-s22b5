using AssistPurchaseTest.Util;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;

namespace AssistPurchaseTest.DataAccessLayerTest
{
    public class InterestedCustomerImplTest
    {
        private readonly IInterestedCustomer _interestedCustomer;


        public InterestedCustomerImplTest()
        {
            _interestedCustomer = new InterestedCustomerImpl();
        }

        [Fact]
        public void TestShowAllInterestedCustomers()
        {
            var productList = _interestedCustomer.GetAllInterestedCustomers();
            Assert.True(productList.Any());
        }
        [Fact]
        public void TestValidProductDataAddition()
        {
            Thread.Sleep(100);
            CustomerDetails customer = new CustomerDetails
            {
                ProductName = "x0",
                Email = "pranshu123@gmail.com",
                PhoneNumber = "0987654322"
            };
            Assert.True(_interestedCustomer.InterestedCustomer(customer) == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void TestCustomerData()
        {
            Thread.Sleep(100);
            CustomerDetails customer = new CustomerDetails
            {
                ProductName = "x0",
                Email = "pranshu123@gmail.com",
                PhoneNumber = "0987654322"
            };
            Assert.Equal("x0", customer.ProductName);
            Assert.Equal("pranshu123@gmail.com", customer.Email);
            Assert.Equal("0987654322", customer.PhoneNumber);
        }
        }
}
