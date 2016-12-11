using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class PostManager
    {
        PostGateway _postGateway = new PostGateway();
        public int AddPost(Post post)
        {
            return _postGateway.AddPost(post);
        }

        public int RemovePost(int postId)
        {
            return _postGateway.RemovePost(postId);
        }
    }
}