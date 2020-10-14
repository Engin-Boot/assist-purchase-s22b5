using Xunit;
using System.Collections.Generic;
using DataModel;
using RestSharp;
using RestSharp.Serialization.Json;
namespace AssistPurchaseTest.IntegrationTest
{
    public class ProductControllerIntegrationTest
    {
        private readonly RestClient _restClient;
        private readonly RestRequest _request;
        public ProductControllerIntegrationTest()
        {
            _restClient = new RestClient("http://localhost:53951/api");
            _request = new RestRequest("product/");
        }
        [Fact]
        public void TestAddData()
        {
            
            var data = _restClient.Get(_request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<List<ProductDataModel>>(data);

            Assert.True(output[0].Id == 101);
            Assert.True(output[1].Id == 102);
            Assert.True(output[0].Portable);
        }
    }
}