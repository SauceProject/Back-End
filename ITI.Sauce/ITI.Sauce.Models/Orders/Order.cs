using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List <OrderList> orderLists { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }


    }
}
