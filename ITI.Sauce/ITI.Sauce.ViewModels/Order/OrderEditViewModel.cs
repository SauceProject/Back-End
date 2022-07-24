using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class OrderExtentions
    {
        public static Order ToModel(this OrderEditViewModel model)
        {
            return new Order
            {
                ID = model.ID,
                OrderDate = model.OrderDate,
                IsDeleted = model.IsDeleted,
                UserId =model.UserId,
                orderLists=model.orderLists
            };
        }
    }

    public class OrderEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<OrderList> orderLists { get; set; }


    }
}
