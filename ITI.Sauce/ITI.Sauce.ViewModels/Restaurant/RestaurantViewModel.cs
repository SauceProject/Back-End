using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{

    public static partial class RestaurantExtentions
    {
        public static RestaurantViewModel ToViewModel(this Restaurant model)
        {
            return new RestaurantViewModel
            {
                ID = model.ID,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                Vendor_ID = model.Vendor_ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                RegisterDate = model.RegisterDate,
                IsDeleted = model.IsDeleted,
                ImageUrl = model.ImageUrl,
            };
        }

        public static RestaurantEditViewModel ToEditViewModel(this RestaurantViewModel model)
        {


            return new RestaurantEditViewModel()
            {

                FromDate = model.FromDate,
                ToDate = model.ToDate,
                Vendor_ID = model.Vendor_ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                RegisterDate = model.RegisterDate,
                IsDeleted = model.IsDeleted,
                ImageUrl = model.ImageUrl,
            };
        }




    }



    public class RestaurantViewModel
    {
        public int ID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Vendor_ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
    }
}
