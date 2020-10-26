using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataModel;

namespace AssistPurchaseTest.Util
{
    [ExcludeFromCodeCoverage]
    public static class Helper
    {
        public static ProductInfo GetProductDataModelObject(int id, string productName)
        {
            var testProductDataModel = new ProductInfo
            {
                ProductName = productName,
                Id = id,
                ProductSeries = "Intellivue",
                ProductModel = "X33",
                Weight = 1000,
                Portable = true,
                MonitorResolution = "1024*720",
                ScreenSize = 5,
                Measurement = "SPO2,ECG"
            };
            return testProductDataModel;
        }
    }
}