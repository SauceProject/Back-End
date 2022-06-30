using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class RestaurantExtentions
    {
        public static Restaurant ToModel(this RestaurantEditViewModel model)
        {
            return new Restaurant
            {
                WorkTime = model.WorkTime,
                Vendor_ID = model.Vendor_ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                RegisterDate = model.RegisterDate,
                IsDeleted = model.IsDeleted
            };
        }
    }

    public class RestaurantEditViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime WorkTime { get; set; }
        [Required]
        public int Vendor_ID { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
