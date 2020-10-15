using System.Collections.Generic;
using DataModel;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AssistPurchaseTest.IntegrationTest
{
    public class ChatAppControllerIntegrationTest
    {
        private readonly RestClient _restClient;
        private readonly RestRequest _request;
        private readonly JsonDeserializer _deserializer;

        public ChatAppControllerIntegrationTest()
        {
            _restClient = new RestClient("http://localhost:53951/api");
            _request = new RestRequest("chatapp");
            _deserializer = new JsonDeserializer();
        }
        [Fact]
        public void TestPortableFilter()
        {
            _request.AddQueryParameter("IsPortable", "true");
            var response = _restClient.Get(_request);
            var output = _deserializer.Deserialize<List<ProductDataModel>>(response);
            Assert.NotNull(output);
        }

        [Fact]
        public void TestMeasurementFilter()
        {
            _request.AddQueryParameter("Measurements", "SPO2");
            _request.AddQueryParameter("Measurements", "ECG");
            var response = _restClient.Get(_request);
            var output = _deserializer.Deserialize<List<ProductDataModel>>(response);
            Assert.NotNull(output);
        }

        [Fact]
        public void TestScreenSizeFilter()
        {
            _request.AddQueryParameter("MinScreenSize", "5");
            _request.AddQueryParameter("MaxScreenSize", "10");
            var response = _restClient.Get(_request);
            var output = _deserializer.Deserialize<List<ProductDataModel>>(response);
            Assert.NotNull(output);
        }
    }
}