using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class OrderExtentions
    {
        public static OrderViewModel ToViewModel(this Order model)
        {

            return new OrderViewModel
            {
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                registerDate = model.registerDate,
                IsDeleted = model.IsDeleted,


            };
        }

        public static OrderEditViewModel ToEditViewModel(this OrderViewModel model)
        {


            return new OrderEditViewModel()
            {

                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                registerDate = model.registerDate,
                IsDeleted = model.IsDeleted,

            };
        }
    }
    public class OrderViewModel
    {

        public int ID { get; set; }

        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}

