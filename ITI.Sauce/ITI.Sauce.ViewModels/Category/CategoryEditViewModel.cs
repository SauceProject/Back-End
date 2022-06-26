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
                NameEN = model.NameEN,
                NameAR = model.NameAR,
            };
        }
    }

    public class CategoryEditViewModel
    {
        public string NameEN { get; set; }
        public string NameAR { get; set; }
    }
}
