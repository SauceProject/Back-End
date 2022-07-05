using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ITI.Sauce.ViewModels

{
    public static partial class RecipeExtentions
    {



        public static Recipe ToModel(this RecipeEditViewModel model)
        {
            return new Recipe
            {
                ID = model.ID,
                CategoryID = model.CategoryID,
                Details = model.Details,
                GoodFor = model.GoodFor,
                IsDeleted = model.IsDeleted,
                NameAR = model.NameAR,
                NameEN = model.NameEN,
                Price = model.Price,
                RegisterDate = model.RegisterDate,
                ImageUrl = model.ImageUrl,
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
        [Display(Name = "Good For")]
        public int GoodFor { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        [Display(Name ="Name In English")]
        public string NameEN { get; set; }
        [Required]
        [Display(Name = "Name In Arabic")]
        public string NameAR { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
       
        public IFormFile? Image { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int RestaurantID { get; set; }
    }
}
