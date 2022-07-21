using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class OrderList
    {
        public int OrderListID { get; set; }
        public int OrderListQty { get; set; }
        public float OrderListPrice { get; set; }//subprice
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int Recipe_ID { get; set; }
        public virtual Recipe Recipe { get; set; }

    }
}
