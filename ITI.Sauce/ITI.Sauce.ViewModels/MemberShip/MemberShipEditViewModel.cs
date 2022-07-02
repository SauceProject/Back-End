using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class MemberShipExtentions
    {
        public static MemberShip ToModel(this MemberShipEditViewModel model)
        {
            return new MemberShip
            {
                ID = model.ID,

                OrderNum = model.OrderNum,
                Price = model.Price,
                TypeEn = model.TypeEn,
                TypeAr = model.TypeAr
            };

        }
    }
    public class MemberShipEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string TypeEn { get; set; }
        [Required]
        public string TypeAr { get; set; }
        [Required]
        public int OrderNum { get; set; }
        [Required]
        public float Price { get; set; }


    }
}

