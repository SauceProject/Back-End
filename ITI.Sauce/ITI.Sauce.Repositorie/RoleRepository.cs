using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Identity;


namespace ITI.Sauce.Repository
{
    
    public class RoleRepository : GeneralRepository<IdentityRole>
    {
        RoleManager<IdentityRole> RoleManager;
        public RoleRepository(DBContext _Context , RoleManager<IdentityRole> _RoleManager) : base(_Context)
        {
            RoleManager = _RoleManager;
        }

        public async Task<IdentityResult> Add(RoleEditViewModel model)
        {
            return await RoleManager.CreateAsync(model.ToModel());
        }

        public List<TextValueViewModel> GetDropDownValue() =>
              GetList().Select(i => new TextValueViewModel
              {
                  Value = int.Parse(i.Id),
                  Text = i.Name

              }).ToList();
    }
}
