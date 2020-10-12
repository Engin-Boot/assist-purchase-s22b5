using System.Collections.Generic;
using DataModel;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace ChatAPITest
{
    public class ProductControllerTest
    {
        private readonly RestClient _restClient;
        private readonly RestRequest _request;
        public ProductControllerTest()
        {
            _restClient = new RestClient("http://localhost:53951/api");
            _request = new RestRequest("product/", Method.GET);
        }
        [Fact]
        public void TestGetMethod()
        {
            var data = _restClient.Execute(_request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<List<ProductDataModel>>(data);

            //Console.WriteLine(output.ToString());

            Assert.True(output[0].Id == 101);
            Assert.True(output[1].Id == 102);
            Assert.True(output[0].Portable);


        }
    }
}
