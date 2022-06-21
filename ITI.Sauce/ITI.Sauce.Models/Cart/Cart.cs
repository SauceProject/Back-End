using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int Users_ID { get; set; }
        public int Qty { get; set; }
        public int Recipe_ID { get; set; }
        public Recipe Recipe { get; set; }
        public Users User { get; set; }


    }
}
