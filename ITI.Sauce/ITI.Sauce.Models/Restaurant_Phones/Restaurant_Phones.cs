using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Restaurant_Phones
    {
        public int Restaurant_ID { get; set; }
        public string Restaurant_phone { get; set; }
        public virtual Restaurant Restaurants { get; set; }
    }
}
