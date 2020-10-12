using System.Collections.Generic;
using System.Text;

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
        

        public override string ToString()
        {
            var str=new StringBuilder();
            str.Append("{");
            str.Append(" \"productName\" : \""+ProductName+"\",");
            str.Append(" \"id\" :" + Id + ",");
            str.Append(" \"productSeries\" : \"" + ProductSeries + "\",");
            str.Append(" \"productModel\" : \"" + ProductModel + "\",");
            str.Append(" \"screenSize\" : " + ScreenSize + ",");
            str.Append(" \"productWeight\" : " + Weight +",");
            str.Append(" \"portable\" : " + Portable + ",");
            str.Append(" \"monitorResolution\" : \"" + MonitorResolution + "\",");
            str.Append("\"measurement\" : [");
            var i = 0;
            var measurementArray=new string[Measurement.Count] ;
            foreach (var newMeasurement in Measurement)
            {
                measurementArray[i++] = "\""+newMeasurement+"\"";
            }

            str.Append(string.Join(",",measurementArray));
            str.Append("]}");
            return str.ToString();
        }
    }
}
