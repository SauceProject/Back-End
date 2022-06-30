using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{

    public static partial class MemberShipExtentions
    {
        public static MemberShipViewModel ToViewModel(this MemberShip model)
        {
            return new MemberShipViewModel
            {
               OrderNum = model.OrderNum,
                Price = model.Price,
                TypeEn = model.TypeEn,
                TypeAr = model.TypeAr

            };
        }
    }
        public class MemberShipViewModel
    {
         
        public int ID { get; set; }
        public string TypeEn { get; set; }
        public string TypeAr { get; set; }
        public int OrderNum { get; set; }
        public float Price { get; set; }
       
    
}
}
