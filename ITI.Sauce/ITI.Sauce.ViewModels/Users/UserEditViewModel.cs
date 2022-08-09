using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class UserExtentions
    {
        public static Users ToModel(this UserEditViewModel model)
        {
            return new Users
            {
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber =model.phone,
            };
        }

        public static VendorEditViewModel ToVendorEditViewModel(this UsersViewModel model)
        {
            return new VendorEditViewModel
            {
                Id=model.ID,
                Password=model.Password,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                Email = model.Email,
                Role= "Vendor",
            };
        }
    }
    public class UserEditViewModel
    {
        [Required,StringLength(50,MinimumLength =3)]
        public string? NameEN { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string? NameAR { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("ConfirnmPassword")]
        public string? Password { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? ConfirnmPassword { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        public string? phone { get; set; }
        [Required]
        public string? Role { get; set; } = "Vendor";
    }
}
