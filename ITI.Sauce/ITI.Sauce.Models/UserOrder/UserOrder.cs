using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class UserOrder
    {
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public Users User { get; set; }
        public Order Order { get; set; }


    }
}
