using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;



namespace ITI.Sauce.ViewModels
{
    public static partial class IngredientExtensions
    {
        public static Ingredient ToModel(this IngredientEditViewModel model)
        {
            return new Ingredient
            {
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                ImageUrl = model.ImageUrl,
            };
        }
    }

    public class IngredientEditViewModel
    {
        public string NameEN { get; set; }
        public string NameAR { get; set; }

        public string ImageUrl { get; set; }
    }
}
