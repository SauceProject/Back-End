using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class RatingExtentions
    {


        public static Rating ToModel(this RatingEditViewModel model)
        {
            return new Rating
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
    public class RatingEditViewModel
    {
        [Required]
        public int RatingID { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int RatingValue { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public int RecipeID { get; set; }
        [Required]
        public string UserID { get; set; }
        //[Required]
        //public bool IsDeleted { get; set; }



    }
}
