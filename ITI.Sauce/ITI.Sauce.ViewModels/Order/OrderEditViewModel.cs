using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class OrderExtentions
    {
        public static Order ToModel(this OrderEditViewModel model)
        {
            return new Order
            {
                ID = model.ID,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                registerDate = model.registerDate,
                IsDeleted = model.IsDeleted,
                Recipe_ID =model.Recipe_ID,
            };
        }
    }

    public class OrderEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameAR { get; set; }
        [Required]
        public DateTime registerDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public int Recipe_ID { get; set; }

    }
}
