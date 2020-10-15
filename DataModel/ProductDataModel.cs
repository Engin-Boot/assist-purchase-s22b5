using System.Collections.Generic;

namespace DataModel
{
    
    public class ProductDataModel
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public string ProductSeries { get; set; }
        public string ProductModel { get; set; }
        public double ScreenSize { get; set; }
        public double Weight { get; set; }
        public bool Portable { get; set; }
        public string MonitorResolution { get; set; }
        public List<string> Measurement { get; set; }
    }
}
