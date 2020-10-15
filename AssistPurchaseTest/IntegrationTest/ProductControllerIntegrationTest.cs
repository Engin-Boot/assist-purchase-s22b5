﻿using Xunit;
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
            _request = new RestRequest("product");
        }

        private ProductDataModel GetProductDataModelObject(int id, string productName)
        {
            var testProductDataModel = new ProductDataModel
            {
                ProductName = productName,
                Id = id,
                ProductSeries = "Intellivue",
                ProductModel = "X3333",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            return testProductDataModel;
        }
        [Fact]
        public void TestGetData()
        {
            
            var data = _restClient.Get(_request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<List<ProductDataModel>>(data);

            Assert.True(output[0].Id == 1);
            Assert.True(output[1].Id == 2);
            Assert.True(output[0].Portable);
        }

        [Fact]
        public void IntegrationTest()
        {
            var testProductDataModel = GetProductDataModelObject(11, "Test2");
            TestAddData(testProductDataModel);
            TestUpdateData(testProductDataModel);
            TestRemoveData(testProductDataModel);
        }
        private void TestAddData(ProductDataModel testProductDataModel)
        {
           
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Post(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);

        }
        
        private void TestRemoveData(ProductDataModel testProductDataModel)
        {
            _request.AddHeader("Content-Type", "application/json; charset=utf-8");
            _request.AddJsonBody(testProductDataModel);
            var data = _restClient.Delete(_request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<HttpStatusCode>(data);

            Assert.Equal(HttpStatusCode.OK, output);

        }

        private void TestUpdateData(ProductDataModel testProductDataModel)
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