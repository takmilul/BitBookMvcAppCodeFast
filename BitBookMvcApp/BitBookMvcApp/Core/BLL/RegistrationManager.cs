using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.BLL;
using BitBookMvcApp.Models;
using BitBookMvcApp.ViewModels.Registration;

namespace BitBookMvcApp.Core.BLL
{
    public class RegistrationManager
    {
        UserManager _userManager = new UserManager();
        ProfileManager _profileManager = new ProfileManager();
        public int SaveUser(Registration userInput)
        {
            User user = new User { Email = userInput.Email, Password = userInput.Password };

            bool isUserExist = _userManager.GetUserByEmail(user.Email) != null;
            if (isUserExist)
            {
                throw new Exception("Email already exist");
            }
            int userId = _userManager.InsertUser(user);
            Profile profile = new Profile { FirstName = userInput.FirstName, LastName = userInput.LastName, DateOfBirth = userInput.DateOfBirth, Gender = userInput.Gender, UserId = userId, CreateDate = DateTime.Today };
            int profileRowsAffected = _profileManager.InsertProfile(profile);

            if (userId < 1 || profileRowsAffected < 1)
            {
                return 0;
            }
            return 1;
        }
    }
}