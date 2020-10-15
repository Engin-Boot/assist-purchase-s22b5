using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataModel;

namespace AssistPurchaseTest.Util
{
    [ExcludeFromCodeCoverage]
    public static class Helper
    {
        public static ProductDataModel GetProductDataModelObject(int id, string productName)
        {
            var testProductDataModel = new ProductDataModel
            {
                ProductName = productName,
                Id = id,
                ProductSeries = "Intellivue",
                ProductModel = "X33",
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
    }
}