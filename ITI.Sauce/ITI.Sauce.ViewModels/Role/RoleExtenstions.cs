using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ITI.Sauce.ViewModels
{
    public static class RoleExtenstions
    {
        public static IdentityRole ToModel(this RoleEditViewModel model)
        {
            return new IdentityRole
            {
                Id = model.ID.ToString(),   
                Name = model.Name
            };
        }
    }
}
