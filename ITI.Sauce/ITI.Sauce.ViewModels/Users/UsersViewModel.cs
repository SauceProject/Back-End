using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class UserExtentions
    {
        public static UsersViewModel ToViewModel(this Users model)
        {

            return new UsersViewModel
            {
                NameEN=model.NameEN,
                NameAR=model.NameAR,
                Email=model.Email,
              
            };
        }
    }
    public class UsersViewModel
    {
        public string? ID { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? phone { get; set; }
        public string? NameEN { get; set; }
        public string? NameAR { get; set; }
        public string? Role { get; set; } = "Vendor";
        public DateTime registerDate { get; set; }
        public bool IsDelete { get; set; }


      


    }
}
