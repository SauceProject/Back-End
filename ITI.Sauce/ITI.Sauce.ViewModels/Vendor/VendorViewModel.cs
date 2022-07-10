using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;


namespace ITI.Sauce.ViewModels
{
    public static partial class VendorExtentions
    {
        public static VendorViewModel ToViewModel(this Vendor model)
        {

            return new VendorViewModel
            {
                ID = model.ID,
                UserName = model.User.UserName,
                
                NameEN = model.User.NameEN,
                NameAR = model.User.NameAR,
                Email = model.User.Email,
                phone = model.User.PhoneNumber,
                Vendor_MemberShips=model.Vendor_MemberShips
                
               

            };
        }

        public static VendorEditViewModel ToEditViewModel(this VendorViewModel model)
        {


            return new VendorEditViewModel()
            {

                Id = model.ID,
                
                IsDeleted = model.IsDeleted,

            };
        }


    }
    public class VendorViewModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Vendor_MemberShip>? Vendor_MemberShips { get; set; }


    }
}
