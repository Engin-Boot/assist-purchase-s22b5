using System.Collections.Generic;
using System.Net;
using ChatAPI.Controllers;
using ChatAPI.Utils;
using DataAccessLayer;
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
    }
}
