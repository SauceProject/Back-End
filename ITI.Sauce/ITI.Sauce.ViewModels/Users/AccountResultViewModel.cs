using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ITI.Sauce.ViewModels
{
    public class AccountResultViewModel
    {
        public bool IsSuccess { get; set; }
        public string UserId { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
