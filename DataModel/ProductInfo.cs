using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public string ProductSeries { get; set; }
        public string ProductModel { get; set; }
        public double ScreenSize { get; set; }
        public double Weight { get; set; }
        public bool Portable { get; set; }
        public string MonitorResolution { get; set; }
        public string Measurement { get; set; }
    }
}
