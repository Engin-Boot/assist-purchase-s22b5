using Xunit;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using DataModel;
using AssistPurchaseTest.Util;
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
            _request = new RestRequest("products");
        }

        
        [Fact]
        public void TestGetData()
        {
            
            var data = _restClient.Get(_request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<List<ProductInfo>>(data);

            Assert.True(output[0].Id == 1);
            Assert.True(output[1].Id == 2);
            Assert.True(output[0].Portable);
        }

        [Fact]
        public void IntegrationTest()
        {
            var num = RandomNumberGenerator.GetInt32(1000) + 10;
            var testProductDataModel = Helper.GetProductDataModelObject(num, "Test"+num);
            TestAddData(testProductDataModel);
            TestUpdateData(testProductDataModel);
            TestRemoveData(testProductDataModel);
        }
        private void TestAddData(ProductInfo testProductDataModel)
        {
           
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Post(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);

        }
        
        private void TestRemoveData(ProductInfo testProductDataModel)
        {
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Delete(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);

        }

        private void TestUpdateData(ProductInfo testProductDataModel)
        {
            testProductDataModel.Weight = 900;
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Put(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);
        }
       
    }
}