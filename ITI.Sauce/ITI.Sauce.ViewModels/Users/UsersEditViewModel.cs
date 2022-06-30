using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class UsersExtentions
    {

        public static Users ToModel(this UsersEditViewModel model)
        {
            return new Users
            {
                
                UserName = model.UserName,
               Password = model.Password,
                Email = model.Email,
                phone = model.phone,
                NameEN = model.NameEN,
                NameAR = model.NameAR,
                registerDate = model.registerDate,
                IsDelete = model.IsDelete

            };
        }
    }

    public class UsersEditViewModel
    {
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
        public DateTime registerDate { get; set; }
        public bool IsDelete { get; set; }
    }
}