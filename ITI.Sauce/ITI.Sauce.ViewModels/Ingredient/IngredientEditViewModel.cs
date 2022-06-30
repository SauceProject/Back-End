using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ITI.Sauce.ViewModels
{
    public static partial class IngredientExtensions
    {
        public static Ingredient ToModel(this IngredientEditViewModel model)
        {
            return new Ingredient
            {
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                ImageUrl = model.ImageUrl,
            };
        }
    }

    public class IngredientEditViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile? Image { get; set; }


    }
}
