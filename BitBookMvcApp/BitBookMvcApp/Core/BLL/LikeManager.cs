using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class LikeManager
    {
        LikeGateway _likeGateway = new LikeGateway();

        public int LikePost(int postId, int userId)
        {
            return _likeGateway.LikePost(postId, userId);
        }

        public int UnlikePost(int postId, int userId)
        {
            return _likeGateway.UnlikePost(postId, userId);
        }

        public int TotalLike(int postId)
        {
            return _likeGateway.GetAllLikeList(postId).Last().TotalLike;
        }

        public List<Like> GetAllLikeList(int postId)
        {
            return _likeGateway.GetAllLikeList(postId);
        }
    }
}