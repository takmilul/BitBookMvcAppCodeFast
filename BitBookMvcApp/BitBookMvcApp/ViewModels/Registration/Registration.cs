using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitBookMvcApp.ViewModels.Registration
{
    public class Registration
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please Enter Currect Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Please Re-Type Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Birthday")]
        [Required(ErrorMessage = "Please Enter Your Birth Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Select Your Gender")]
        public string Gender { get; set; }

        public Registration()
        {

        }
        public Registration(int id, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string gender)
            : this(firstName, lastName, email, password, dateOfBirth, gender)
        {
            Id = id;
        }

        public Registration(string firstName, string lastName, string email, string password, DateTime dateOfBirth, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
    }
}