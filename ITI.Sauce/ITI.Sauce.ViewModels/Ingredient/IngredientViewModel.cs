using ITI.Sauce.Models;
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
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                ImageUrl = model.ImageUrl

            };
        }

        public static IngredientEditViewModel ToEditViewModel(this IngredientViewModel model)
        {


            return new IngredientEditViewModel()
            {

                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                ImageUrl = model.ImageUrl,
                IsDeleted = model.IsDeleted,

            };
        }
    }

    public class IngredientViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }



    }

}
