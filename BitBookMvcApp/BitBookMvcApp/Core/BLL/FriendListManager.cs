using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class FriendListManager
    {
        FriendListGateway _friendListGateway = new FriendListGateway();

        public int AddFriend(int friendId, int userId)
        {
            return _friendListGateway.AddFriend(friendId, userId);
        }

        public int UnFriend(int friendId, int userId)
        {
            return _friendListGateway.UnFriend(friendId, userId);
        }

        public List<FriendList> GetAllFriendList(int userId)
        {
            return _friendListGateway.GetAllFriendList(userId);
        }
    }
}