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
        public static Vendor ToModel(this VendorEditViewModel model)
        {
            return new Vendor
            {
                ID = model.ID,
                //UserName = model.UserName,
                //Password = model.Password,
                //NameEN = model.NameEN,
                //NameAR = model.NameAR,
                //Email = model.Email,
                //phone = model.phone,
                IsDeleted=model.IsDeleted,
            };
        }
    }
    public class VendorEditViewModel
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameAR { get; set; }
        public bool IsDeleted { get; set; }
    }
}
