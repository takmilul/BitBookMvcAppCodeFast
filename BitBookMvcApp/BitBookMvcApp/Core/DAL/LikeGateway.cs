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
    public class LikeGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int LikePost(int postId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Like (PostId, WhoLikedId) VALUES(@PostId, @WhoLikedId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@PostId", SqlDbType.Int);
            command.Parameters["@PostId"].Value = postId;
            command.Parameters.Add("@WhoLikedId", SqlDbType.Int);
            command.Parameters["@WhoLikedId"].Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UnlikePost(int postId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM Like WHERE PostId=@PostId AND WhoLikedId=@WhoLikedId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@PostId", SqlDbType.Int);
            command.Parameters["@PostId"].Value = postId;
            command.Parameters.Add("@WhoLikedId", SqlDbType.Int);
            command.Parameters["@WhoLikedId"].Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<Like> GetAllLikeList(int postId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SP_ViewLikeList";
            SqlCommand command = new SqlCommand(query, connection){CommandType = CommandType.StoredProcedure};
            command.Parameters.Clear();
            command.Parameters.Add("@PostId", SqlDbType.Int);
            command.Parameters["@PostId"].Value = postId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Like> likeList = new List<Like>();
            while (reader.HasRows)
            {
                Like like = new Like
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PostId = Convert.ToInt32(reader["PostId"]),
                    WhoLikedId = Convert.ToInt32(reader["WhoLikedId"]),
                    FullName = Convert.ToString(reader["FullName"]),
                    ProPicUrl = Convert.ToString(reader["PicUrl"]),
                    TotalLike = Convert.ToInt32(reader["TotalLike"])
                };

                likeList.Add(like);
            }
            connection.Close();
            reader.Close();
            return likeList;
        }
    }
}