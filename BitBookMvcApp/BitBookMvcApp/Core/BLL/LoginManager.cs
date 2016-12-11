using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class LoginManager
    {
        UserGateway userGetway = new UserGateway();
        UserManager _userManager = new UserManager();

        public bool isValidUser(User user)
        {

            if (!_userManager.IsEmailExitst(user.Email))
            {
                return false;
            }
            User existingUser = _userManager.GetUserByEmail(user.Email);
            if (user.Email == existingUser.Email && user.Password == existingUser.Password)
            {
                return true;
            }
            return false;
        }

        public bool CheckSession(User user)
        {
            bool isSessionExist = false;
            if (user != null)
            {
                isSessionExist = true;
            }
            return isSessionExist;
        }
    }
}