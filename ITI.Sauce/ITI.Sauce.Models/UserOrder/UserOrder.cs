using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class UserOrder
    {
        public string UserID { get; set; }
        public int OrderID { get; set; }
        public virtual Users User { get; set; }
        public virtual Order Order { get; set; }


    }
}
