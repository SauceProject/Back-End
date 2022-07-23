using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class OrderListExtensions
    {
        public static OrderListViewModel ToViewModel(this OrderList model)
        {
            return new OrderListViewModel
            {
                OrderListID = model.OrderListID,
                OrderListQty = model.OrderListQty,
                OrderListPrice = model.OrderListPrice,
                RecipeID = model.Recipe_ID,
                OrderID = model.OrderID,
            };
        }

        public static OrderListEditViewModel ToEditViewModel(this OrderListViewModel model)
        {


            return new OrderListEditViewModel()
            {

                OrderListID = model.OrderListID,
                OrderListQty = model.OrderListQty,
                OrderListPrice = model.OrderListPrice,
                RecipeID = model.RecipeID,
                OrderID = model.OrderID,

            };
        }


    }



    public class OrderListViewModel
    {
        public int OrderListID { get; set; }
        public int OrderListQty { get; set; }
        public float OrderListPrice { get; set; }
        public int RecipeID { get; set; }
        public int OrderID { get; set; }
        
    }
}
