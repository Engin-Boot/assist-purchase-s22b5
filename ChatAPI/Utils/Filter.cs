using System.Collections.Generic;

namespace ChatAPI.Utils
{
    public class Filter
    {
       
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public double Price { get; set; }
        public string IsPortable { get; set; }
        public string DataSharing { get; set; }
        public List<string> Measurements { get; set; }
        public double MinScreenSize { get; set; }
        public double MaxScreenSize { get; set; }

        
    }
}
