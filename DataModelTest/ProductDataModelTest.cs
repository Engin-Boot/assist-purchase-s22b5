using System.Collections.Generic;
using DataModel;
using Xunit;

namespace DataModelTest
{
    public class ProductDataModelTest
    {
        [Fact]
        public void TestToStringData()
        {
            var testProd = new ProductDataModel
            {
                ProductName = "IntelliVue X3",
                Id = 104,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.False(string.IsNullOrEmpty(testProd.ToString()));
            testProd = new ProductDataModel
            {
                ProductName = "",
                Id = 104,
                ProductSeries = "Intellivue",
                ProductModel = "X3",
                ProductPrice = 1000000,
                ProductWeight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                Measurement = new List<string>()
                {
                    "SPO2", "ECG"
                }
            };
            Assert.True(string.IsNullOrEmpty(testProd.ProductName));

        }
    }
}
