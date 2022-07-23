using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using System.ComponentModel.DataAnnotations;


namespace ITI.Sauce.ViewModels
{
    public static partial class OrderListExtensions
    {
        public static OrderList ToModel(this OrderListEditViewModel model)
        {
            return new OrderList
            {
                OrderListID = model.OrderListID,
                OrderListQty = model.OrderListQty,
                OrderListPrice = model.OrderListPrice,
                Recipe_ID = model.RecipeID,
                OrderID = model.OrderID,
            };

        }
    }
    public class OrderListEditViewModel
    {
        public int OrderListID { get; set; }
        public int OrderListQty { get; set; }
        public float OrderListPrice { get; set; }
        public int RecipeID { get; set; }
        public int OrderID { get; set; }

    }
}
