using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using Microsoft.AspNetCore.Http;

namespace ITI.Sauce.ViewModels
{
    public static partial class RestaurantExtentions
    {
        public static Restaurant ToModel(this RestaurantEditViewModel model)
        {
            return new Restaurant
            {
                ID = model.ID,  
                WorkTime = model.WorkTime,
                Vendor_ID = model.Vendor_ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                RegisterDate = model.RegisterDate,
                IsDeleted = model.IsDeleted,
                ImageUrl = model.ImageUrl,
            };
        }
    }

    public class RestaurantEditViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime WorkTime { get; set; }
        [Required]
        public string Vendor_ID { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
