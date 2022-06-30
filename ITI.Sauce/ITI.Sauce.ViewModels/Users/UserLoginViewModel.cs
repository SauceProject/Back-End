using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public class UserLoginViewModel
    {
        [Required ,StringLength(50,MinimumLength = 3),EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password),StringLength(50,MinimumLength =3) ]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Remmeber Me")]
        public bool RemmeberMe { get; set; }
    }
}
