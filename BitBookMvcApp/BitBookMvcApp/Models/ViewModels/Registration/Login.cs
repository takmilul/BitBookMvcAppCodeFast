using System.ComponentModel.DataAnnotations;

namespace BitBookMvcApp.Models.ViewModels.Registration
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please Enter Currect Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        //[Remote("UserAuthentication", "Login", ErrorMessage = "Wrong UserName or password")]
        public string Password { get; set; }
    }
}