using System.Collections.Generic;
using System.Net;
using ChatAPI.Controllers;
using ChatAPI.Utils;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistPurchaseTest.ChatAPITest
{
    public class ChatAppControllerTest
    {
        private readonly ChatAppController _chatAppController;

        public ChatAppControllerTest()
        {
            IProductManagement productDb = new ProductManagementMemoryDb();
            _chatAppController = new ChatAppController(productDb);
        }

        [Fact]
        public void WhenCustomerMailIdIsInvalidThenReturnTrue()
        {
            var dummyMailData = new Mailer
            {
                CustomerEmailId = "test@test.com", ProductNameList = new List<string>() {"MX450", "MX7500"}
            };
            var response = _chatAppController.Post(dummyMailData);
            Assert.True(response==HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestPortableFilter()
        {
            var dummyFilter = new Filter
            {
                IsPortable = "true"
            };
            var response = _chatAppController.FilterProducts(dummyFilter);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void TestMeasurementFilter()
        {
            var dummyFilter = new Filter
            {
                Measurements = new List<string>(){"SPO2"}
            };
            var response = _chatAppController.FilterProducts(dummyFilter);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void TestScreenSizeFilter()
        {
            var dummyFilter = new Filter
            {
                MinScreenSize = 15,
                MaxScreenSize = 25
            };
            var response = _chatAppController.FilterProducts(dummyFilter);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void TestWeightFilter()
        {
            var dummyFilter = new Filter
            {
                MinWeight = 1200,
                MaxWeight = 2200
            };
            var response = _chatAppController.FilterProducts(dummyFilter);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
    }
}
