using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public class OrderListViewModel
    {
        public int OrderListID { get; set; }
        public int OrderListQty { get; set; }
        public float OrderListPrice { get; set; }
        public int RecipeID { get; set; }
        public int OrderID { get; set; }
        
    }
}
