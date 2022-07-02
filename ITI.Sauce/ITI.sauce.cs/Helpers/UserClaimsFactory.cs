using System.Security.Claims;
using ITI.Sauce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ITI.Sauce.MVC.Helpers
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<Users>
    {
        UserManager<Users> UserManager;
        public UserClaimsFactory(UserManager<Users> _userManager, 
            IOptions<IdentityOptions> optionsAccessor) : base(_userManager, optionsAccessor)
        {
            UserManager = _userManager;
        }
       protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Users User)
        {
            var claims = await base.GenerateClaimsAsync(User);
            var result = await UserManager.GetRolesAsync(User);
            List<String> roles = result.ToList();

            foreach (string role in roles)
            claims.AddClaim(new Claim( role , role));

            return claims;
        }
    }
}
