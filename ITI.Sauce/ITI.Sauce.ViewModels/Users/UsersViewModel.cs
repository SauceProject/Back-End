﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels
{
    public static partial class UsersExtentions
    {
        public static UsersViewModel ToViewModel(this Users model)
        {

            return new UsersViewModel
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
    public class UsersViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDelete { get; set; }


      


    }
}
