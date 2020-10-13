using System;
using System.Collections.Generic;
using System.Text;
using ChatAPI.Controllers;
using ChatAPI.Utils;
using DataAccessLayer;
using Xunit;

namespace ChatAPITest
{
    public class ChatAppControllerTest
    {
        private readonly ChatAppController _chatAppController;
        private readonly IProductManagement _productDb;

        public ChatAppControllerTest()
        {
            _productDb = new ProductManagementMemoryDb();
            _chatAppController = new ChatAppController(_productDb);
        }

        [Fact]
        public void WhenCustomerMailIdIsInvalidThenReturnTrue()
        {   
            var dummyMailData = new Mailer();
            dummyMailData.CustomerEmailId = "test@test.com";
            dummyMailData.ProductNameList = new List<string>(){ "MX450", "MX7500"};
            var response = _chatAppController.Post(dummyMailData);
        }
    }
}
