using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public  static partial class CartExtensions
    {
        public static Cart ToModel(this CartEditViewModel model)
        {
            return new Cart
            {
                Recipe_ID=model.Recipe_ID,
                UserID=model.UserID,
                Qty=model.Qty,

            };
        }
    }
    public class CartEditViewModel
    {
        public int ID { get; set; }
        public string? UserID { get; set; }
        public int Qty { get; set; }
        public int Recipe_ID { get; set; }
    }
}
