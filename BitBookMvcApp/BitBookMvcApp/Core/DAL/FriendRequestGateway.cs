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
    public class FriendRequestGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public List<FriendRequest> ViewSendFriendRequestList(int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "sp_SendFriendRequestList";
            SqlCommand command = new SqlCommand(query, connection) {CommandType = CommandType.StoredProcedure};
            command.Parameters.Clear();
            command.Parameters.Add("@SenderId", SqlDbType.Int);
            command.Parameters["@SenderId"].Value = userId;
            command.Parameters.Add("@IsAccepted", SqlDbType.Bit);
            command.Parameters["@IsAccepted"].Value = false;
            List<FriendRequest> friendRequestList = new List<FriendRequest>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                FriendRequest friendRequest = new FriendRequest
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ReceiverId = Convert.ToInt32(reader["ReceiverId"]),
                    FullName = Convert.ToString(reader["FullName"]),
                    ProPicUrl = Convert.ToString(reader["PicUrl"])
                };
                
                friendRequestList.Add(friendRequest);
            }
            connection.Close();
            reader.Close();
            return friendRequestList;
        }

        public List<FriendRequest> ViewGetFriendRequestList(int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "sp_GetFriendRequestList";
            SqlCommand command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@ReceiverId", SqlDbType.Int);
            command.Parameters["@ReceiverId"].Value = userId;
            command.Parameters.Add("@IsAccepted", SqlDbType.Bit);
            command.Parameters["@IsAccepted"].Value = false;
            List<FriendRequest> friendRequestList = new List<FriendRequest>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                FriendRequest friendRequest = new FriendRequest
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    SenderId = Convert.ToInt32(reader["SenderId"]),
                    FullName = Convert.ToString(reader["FullName"]),
                    ProPicUrl = Convert.ToString(reader["PicUrl"])
                };

                friendRequestList.Add(friendRequest);
            }
            connection.Close();
            reader.Close();
            return friendRequestList;
        }

        public int SendFriendRequest(int receiverId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO FriendRequest (SenderId, ReceiverId, IsAccepted) VALUES(@SenderId, @ReceiverId, @IsAccepted)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@SenderId", SqlDbType.Int);
            command.Parameters["@SenderId"].Value = userId;
            command.Parameters.Add("@ReceiverId", SqlDbType.Int);
            command.Parameters["@ReceiverId"].Value = receiverId;
            command.Parameters.Add("@IsAccepted", SqlDbType.Bit);
            command.Parameters["@IsAccepted"].Value = false;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AcceptFriendRequest(int senderId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE FriendRequest SET IsAccepted=@IsAccepted WHERE SenderId=@SenderId AND ReceiverId=@ReceiverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@SenderId", SqlDbType.Int);
            command.Parameters["@SenderId"].Value = senderId;
            command.Parameters.Add("@ReceiverId", SqlDbType.Int);
            command.Parameters["@ReceiverId"].Value = userId;
            command.Parameters.Add("@IsAccepted", SqlDbType.Bit);
            command.Parameters["@IsAccepted"].Value = true;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int RejectFriendRequest(int senderId, int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM FriendRequest WHERE SenderId=@SenderId AND ReceiverId=@ReceiverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@SenderId", SqlDbType.Int);
            command.Parameters["@SenderId"].Value = senderId;
            command.Parameters.Add("@ReceiverId", SqlDbType.Int);
            command.Parameters["@ReceiverId"].Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
    }
}