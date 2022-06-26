﻿using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public static partial class IngredientExtensions
    {
        public static IngredientViewModel ToViewModel(this Ingredient model)
        {
            return new IngredientViewModel
            {

                NameEN = model.NameEN,
                NameAR = model.NameAR,
                ImageUrl = model.ImageUrl
            };
        }
    }

    public class IngredientViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public string ImageUrl { get; set; }


    }
}
