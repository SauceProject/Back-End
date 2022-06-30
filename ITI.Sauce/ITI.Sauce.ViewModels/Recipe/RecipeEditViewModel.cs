using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI.Sauce.ViewModels

{
    public static partial class VendorExtentions
    {


        public static Recipe ToModel(this RecipeEditViewModel model)
        {
            return new Recipe
            {
                ID = model.ID,
                CategoryID = model.CategoryID,
                Details = model.Details,
                GoodFor = model.GoodFor,
                ImageUrl = model.ImageUrl,
                IsDeleted = model.IsDeleted,
                NameAR = model.NameAR,
                NameEN = model.NameEN,
                Price = model.Price,
                RegisterDate = model.RegisterDate,
                VideoUrl = model.VideoUrl,
            };
        }
    }
    public class RecipeEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public int GoodFor { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameAR { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
