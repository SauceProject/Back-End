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
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

    }
}
