using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public static partial class CategoryExtensions
    {
        public static CategoryViewModel ToViewModel(this Category model)
        {
            return new CategoryViewModel
            {
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
            };
        }

        public static CategoryEditViewModel ToEditViewModel(this CategoryViewModel model)
        {


            return new CategoryEditViewModel()
            {

                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                IsDeleted = model.IsDeleted,

            };
        }


    }


    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }

        public bool IsDeleted { get; set; }




    }
}
