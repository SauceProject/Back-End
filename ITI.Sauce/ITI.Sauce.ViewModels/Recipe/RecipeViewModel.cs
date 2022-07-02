using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public static partial class RecipeExtentions
    {
        public static RecipeViewModel ToViewModel(this Recipe model)
        {

            return new RecipeViewModel
            {
                ID=model.ID,
                CategoryID=model.CategoryID,
                Details=model.Details,
                GoodFor=model.GoodFor,
                IsDeleted=model.IsDeleted,
                NameAR=model.NameAR,
                NameEN=model.NameEN,
                Price=model.Price,
                RegisterDate=model.RegisterDate,
                ImageUrl=model.ImageUrl,
                VideoUrl=model.VideoUrl,
            };
        }
    }
    public class RecipeViewModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CategoryID { get; set; }
        public string Details { get; set; }
        public int GoodFor { get; set; }
        public float Price { get; set; }
        public string NameEN { get; set; }

        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
