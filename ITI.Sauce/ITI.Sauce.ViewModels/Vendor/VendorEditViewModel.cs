using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;


namespace ITI.Sauce.ViewModels

{
    public static partial class VendorExtentions
    {


        public static Vendor ToModel(this VendorEditViewModel model)
        {
            return new Vendor
            {
                ID = model.ID,
                UserName = model.UserName,
                Password = model.Password,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                Email = model.Email,
                phone = model.phone,
            };
        }
    }
    public class VendorEditViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
    }
}
