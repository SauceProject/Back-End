using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Location
    {
        public int Restaurant_ID { get; set; }
        public string Location_Name { get; set; }
        public string LocationEN { get; set; }
        public string LocationAR { get; set; }
        public virtual Restaurant Restaurants { get; set; }

    }
}
