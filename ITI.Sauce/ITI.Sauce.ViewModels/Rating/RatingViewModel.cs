using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class RatingExtentions
    {
        public static RatingViewModel ToViewModel(this Rating model)
        {

            return new RatingViewModel
            {
                RatingID = model.RatingID,
                Comment = model.Comment,
                RatingValue = model.RatingValue,
                RecipeID = model.RecipeID,
                UserID = model.UserID,
                IsDeleted=model.IsDeleted,

                
            };
        }
        public static RatingEditViewModel ToEditViewModel(this RatingViewModel model)
        {


            return new RatingEditViewModel()
            {

                RatingID = model.RatingID,
                Comment = model.Comment,
                RatingValue = model.RatingValue,
                RecipeID = model.RecipeID,
                UserID = model.UserID,
                IsDeleted = model.IsDeleted,



            };
        }




    }




    public class RatingViewModel
    {
        public int RatingID { get; set; }
        public string Comment { get; set; }
        public int RatingValue { get; set; }
        public bool IsDeleted { get; set; }
        public int RecipeID { get; set; }
        public string UserID { get; set; }
       

    }
}
