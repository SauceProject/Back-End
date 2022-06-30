﻿using System;
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
                WorkTime = model.WorkTime,
                Vendor_ID = model.Vendor_ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                RegisterDate = model.RegisterDate,
                IsDeleted = model.IsDeleted
            };
        }
    }
        public class RestaurantViewModel
    {
        public int ID { get; set; }
        public DateTime WorkTime { get; set; }
        public int Vendor_ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
