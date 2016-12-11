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
    public class PostGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int AddPost(Post post)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddPost";
            var command = new SqlCommand(query, connection){CommandType = CommandType.StoredProcedure};
            command.Parameters.Clear();
            command.Parameters.Add("@Post", SqlDbType.VarChar);
            command.Parameters["@Post"].Value = post.UsersPost;
            command.Parameters.Add("@PicUrl", SqlDbType.VarChar);
            command.Parameters["@PicUrl"].Value = post.PicUrl;
            command.Parameters.Add("@IsText", SqlDbType.Bit);
            command.Parameters["@IsText"].Value = post.isText;
            command.Parameters.Add("@IsPic", SqlDbType.Bit);
            command.Parameters["@IsPic"].Value = post.isPic;
            command.Parameters.Add("@Date", SqlDbType.DateTime);
            command.Parameters["@Date"].Value = post.Date;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = post.UserId;
            connection.Open();
            int postId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return postId;
        }

        public int RemovePost(int postId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM Post WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = postId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Post GetPost(int postId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Post WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = postId;
            connection.Open();
            var reader = command.ExecuteReader();
            Post post = null;
            if (reader.Read())
            {
                post = new Post
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UsersPost = Convert.ToString(reader["UsersPost"]),
                    PicUrl = Convert.ToString(reader["PicUrl"]),
                    isText = Convert.ToBoolean(reader["isText"]),
                    isPic = Convert.ToBoolean(reader["isPic"]),
                    Date = Convert.ToDateTime(reader["Date"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return post;
        }

        public List<Post> GetAllPosts(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Post WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<Post> postList = new List<Post>();
            while (reader.Read())
            {
                Post post = new Post
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UsersPost = Convert.ToString(reader["UsersPost"]),
                    PicUrl = Convert.ToString(reader["PicUrl"]),
                    isText = Convert.ToBoolean(reader["isText"]),
                    isPic = Convert.ToBoolean(reader["isPic"]),
                    Date = Convert.ToDateTime(reader["Date"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                postList.Add(post);
            }
            reader.Close();
            connection.Close();
            return postList;
        }
    }
}