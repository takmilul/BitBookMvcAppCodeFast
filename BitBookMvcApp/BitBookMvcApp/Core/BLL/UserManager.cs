using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class UserManager
    {
        UserGateway _userGateway = new UserGateway();
        
        public User GetUserByEmail(string email)
        {
            return _userGateway.GetUserByEmail(email);
        }

        public int ChangePassword(string oldPassword, string newPassword, int userId)
        {
            if (IsPasswordMatched(oldPassword, userId))
            {
                return _userGateway.ChangePassword(newPassword, userId);
            }
            throw new Exception("Old password did not match!");
            return 0;
        }

        public bool IsEmailExitst(string email)
        {
            if (GetUserByEmail(email) != null)
            {
                return true;
            }
            return false;
        }

        private bool IsPasswordMatched(string oldPassword, int userId)
        {
            User user = _userGateway.GetUserById(userId);
            if (user != null)
            {
                if (oldPassword.Equals(user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public int InsertUser(User user)
        {
            return _userGateway.InsertUser(user);
        }
    }
}