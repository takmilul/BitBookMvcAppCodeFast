using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class FriendRequestManager
    {
        FriendRequestGateway _friendRequestGateway = new FriendRequestGateway();
        public List<FriendRequest> ViewSendFriendRequestList(int userId)
        {
            return _friendRequestGateway.ViewSendFriendRequestList(userId);
        }

        public List<FriendRequest> ViewGetFriendRequestList(int userId)
        {
            return _friendRequestGateway.ViewGetFriendRequestList(userId);
        }

        public int SendFriendRequest(int receiverId, int userId)
        {
            return _friendRequestGateway.SendFriendRequest(receiverId, userId);
        }

        public int AcceptFriendRequest(int senderId, int userId)
        {
            return _friendRequestGateway.AcceptFriendRequest(senderId, userId);
        }

        public int RejectFriendRequest(int senderId, int userId)
        {
            return _friendRequestGateway.RejectFriendRequest(senderId, userId);
        }
    }
}