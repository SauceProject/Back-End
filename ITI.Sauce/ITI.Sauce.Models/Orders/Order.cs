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
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Recipe_ID { get; set; }
        public virtual List <OrderList> orderLists { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual List<UserOrder> UserOrders { get; set; }


    }
}
