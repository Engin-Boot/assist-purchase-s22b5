using System.Collections.Generic;

namespace DataModel
{
    public class ProductDataModel
    {
        public string ProductName { get; set; }
        public string Id { get; set; }
        public string ProductSeries { get; set; }
        public string ProductModel { get; set; }
        public double ProductPrice { get; set; }
        public double ProductWeight { get; set; }
        public bool Portable { get; set; }
        public    string MonitorResolution { get; set; }
        public List<string> Measurement { get; set; }





        //public Dictionary<string,string> ProductSpecification { get; set; }



    }
}
