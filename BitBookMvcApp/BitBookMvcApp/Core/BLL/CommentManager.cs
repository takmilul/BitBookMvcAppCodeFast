using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class CommentManager
    {
        CommentGateway _commentGateway = new CommentGateway();

        public int AddComment(Comment comment)
        {
            return _commentGateway.AddComment(comment);
        }

        public int RemoveComment(int commentId)
        {
            return _commentGateway.RemoveComment(commentId);
        }
    }
}