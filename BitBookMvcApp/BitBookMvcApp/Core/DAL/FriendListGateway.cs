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
    public class FriendListGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int AddFriend(int friendId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO FriendList (FriendId, UserId) VALUES(@FriendId, @UserId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@FriendId", SqlDbType.Int);
            command.Parameters["@FriendId"].Value = friendId;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UnFriend(int friendId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM FriendList WHERE FriendId=@FriendId AND UserId=@UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@FriendId", SqlDbType.Int);
            command.Parameters["@FriendId"].Value = friendId;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<FriendList> GetAllFriendList(int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SP_ShowFriendList";
            SqlCommand command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<FriendList> friendLists = new List<FriendList>();
            while (reader.HasRows)
            {
                FriendList friendList = new FriendList
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FriendId = Convert.ToInt32(reader["FriendId"]),
                    FriendName = Convert.ToString(reader["FullName"]),
                    ProPicUrl = Convert.ToString(reader["PicUrl"]),
                    UserId = Convert.ToInt32(reader["UserId"])

                };
                friendLists.Add(friendList);
            }
            connection.Close();
            reader.Close();
            return friendLists;
        }
    }
}