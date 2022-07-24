using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class OrderExtentions
    {
        public static OrderViewModel ToViewModel(this Order model)
        {

            return new OrderViewModel
            {
                ID = model.ID,
                OrderDate = model.OrderDate,
                IsDeleted = model.IsDeleted,
                UserId = model.UserId,
                
            };
        }

        public static OrderEditViewModel ToEditViewModel(this OrderViewModel model)
        {


            return new OrderEditViewModel()
            {

                ID = model.ID,
                OrderDate = model.OrderDate,
                IsDeleted = model.IsDeleted,
                UserId = model.UserId,
                orderLists=model.orderLists
            };
        }
    }
    public class OrderViewModel
    {

        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public List<OrderList> orderLists { get; set; }


    }

}

