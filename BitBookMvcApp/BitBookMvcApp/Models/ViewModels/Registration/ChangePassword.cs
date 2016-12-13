using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitBookMvcApp.Models.ViewModels.Registration
{
    public class ChangePassword
    {
        [DisplayName("Old Password")]
        [Required(ErrorMessage = "Please provide old password")]
        public string OldPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Please provide new password")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Please provide confirm password")]
        public string ConfirmPassword { get; set; }
    }
}