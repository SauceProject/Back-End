using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class CategoryExtensions
    {
        public static Category ToModel (this CategoryEditViewModel model )
        {
            return new Category
            {
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                IsDeleted = model.IsDeleted,
            };
        }
    }

    public class CategoryEditViewModel
    {
        public int ID { get; set; }
        public string? NameEN { get; set; }
        public string? NameAR { get; set; }
        public bool IsDeleted { get; set; }


    }
}
