using Xunit;
using System.Collections.Generic;
using System.Net;
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
        public void TestGetData()
        {
            
            var data = _restClient.Get(_request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<List<ProductDataModel>>(data);

            Assert.True(output[0].Id == 101);
            Assert.True(output[1].Id == 102);
            Assert.True(output[0].Portable);
        }

        [Fact]
        public void TestAddData()
        {
            var testProductDataModel = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = 110,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Post(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);

        }

    }
}