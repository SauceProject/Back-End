using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels.Cart
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Qty { get; set; }
        public int Recipe_ID { get; set; }
    }
}
