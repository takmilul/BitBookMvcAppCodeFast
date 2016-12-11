using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.DAL
{
    public class CommentGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int AddComment(Comment comment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Comment (PostId, Comment, Time, WhoCommentedId) VALUES(@PostId, @Comment, @Time, @WhoCommentedId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@PostId", SqlDbType.Int);
            command.Parameters["@PostId"].Value = comment.PostId;
            command.Parameters.Add("@Comment", SqlDbType.VarChar);
            command.Parameters["@Comment"].Value = comment.AComment;
            command.Parameters.Add("@Time", SqlDbType.DateTime);
            command.Parameters["@Time"].Value = comment.Time;
            command.Parameters.Add("@WhoCommentedId", SqlDbType.Int);
            command.Parameters["@WhoCommentedId"].Value = comment.WhoCommentedId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int RemoveComment(int commentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM Comment WHERE Id=@Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = commentId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
    }
}