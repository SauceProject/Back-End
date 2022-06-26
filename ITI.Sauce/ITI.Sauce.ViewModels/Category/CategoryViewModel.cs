﻿using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public static partial class CategoryExtensions
    {
        public static CategoryViewModel ToViewModel(this Category model)
        {
            return new CategoryViewModel
            {
               
                NameEN = model.NameEN,
                NameAR = model.NameAR,
            };
        }
    }


    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }

    }
}
