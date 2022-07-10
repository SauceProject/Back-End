using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public class ChangePasswardViewModel
    {
        public string Id { get; set; }
        [Required , StringLength(50,MinimumLength = 6), DataType(DataType.Password) , Display(Name = "Current Password")]
        public string? CurrentPassword { get; set; }
        [Required, StringLength(50, MinimumLength = 6), DataType(DataType.Password), Display(Name = "New Password")]
        public string? NewPassword { get; set; }
        [Required, StringLength(50, MinimumLength = 6), DataType(DataType.Password),Compare("ConfirmNewPassword"), Display(Name = "Confirm New Password")]
        public string? ConfirmNewPassword { get; set; }


    }
}
