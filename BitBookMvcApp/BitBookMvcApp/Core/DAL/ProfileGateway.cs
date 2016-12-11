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
    public class ProfileGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int InsertProfile(Profile profile)
        {
            var connection = new SqlConnection(connectionString);

            var query = "INSERT INTO Profile (FirstName, LastName, FullName, DOB, Gender, CreateDate, UserId) values(@FirstName, @LastName, @FullName, @DateOfBirth, @Gender, @CreateDate, @UserId)";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            command.Parameters["@FirstName"].Value = profile.FirstName;

            command.Parameters.Add("@LastName", SqlDbType.VarChar);
            command.Parameters["@LastName"].Value = profile.LastName;

            command.Parameters.Add("@FullName", SqlDbType.VarChar);
            command.Parameters["@FullName"].Value = profile.FirstName + " " + profile.LastName;

            command.Parameters.Add("@DateOfBirth", SqlDbType.Date);
            command.Parameters["@DateOfBirth"].Value = profile.DateOfBirth;

            command.Parameters.Add("@Gender", SqlDbType.VarChar);
            command.Parameters["@Gender"].Value = profile.Gender;

            command.Parameters.Add("@CreateDate", SqlDbType.Date);
            command.Parameters["@CreateDate"].Value = profile.CreateDate;

            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = profile.UserId;

            connection.Open();
            var rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Profile GetProfileByUserId(int userId)
        {
            var connection = new SqlConnection(connectionString);
            Profile profile = null;
            var query = "SELECT * FROM Profile WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);
            connection.Open();
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string firstName = Convert.ToString(reader["FirstName"]);
                string lastName = Convert.ToString(reader["LastName"]);
                string fullName = Convert.ToString(reader["FullName"]);
                DateTime dateOfBirth = Convert.ToDateTime(reader["DOB"]);
                string gender = Convert.ToString(reader["Gender"]);
                int proPicId = 0;
                if (!(reader["ProPicId"] is DBNull))
                {
                    proPicId = Convert.ToInt32(reader["ProPicId"]);
                }
                int coverPicId = 0;
                if (!(reader["CoverPicId"] is DBNull))
                {
                    coverPicId = Convert.ToInt32(reader["CoverPicId"]);
                }
                string religion = Convert.ToString(reader["Religion"]);
                bool hasRelationship = false;
                if (!(reader["HasRelationship"] is DBNull))
                {
                    hasRelationship = Convert.ToBoolean(reader["HasRelationship"]);
                }
                string relationship = Convert.ToString(reader["Relationship"]);
                int relationshipWithId = 0;
                if (!(reader["RelationshipWithId"] is DBNull))
                {
                    relationshipWithId = Convert.ToInt32(reader["RelationshipWithId"]);
                }
                string about = Convert.ToString(reader["About"]);
                DateTime createDate = Convert.ToDateTime(reader["CreateDate"]);
                int dbUserId = Convert.ToInt32(reader["UserId"]);

                profile = new Profile(id, firstName, lastName, fullName, dateOfBirth, gender, proPicId, coverPicId, religion, hasRelationship, relationship, relationshipWithId, about, createDate, dbUserId);
            }

            reader.Close();
            connection.Close();
            return profile;
        }

        public List<Profile> GetProfileListByName(string name)
        {
            var connection = new SqlConnection(connectionString);
            List<Profile> profileList = new List<Profile>();
            var query = "select  * from Profile where FullName like '%@Name%'";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = name;
            connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string firstName = Convert.ToString(reader["FirstName"]);
                string lastName = Convert.ToString(reader["LastName"]);
                string fullName = Convert.ToString(reader["FullName"]);
                DateTime dateOfBirth = Convert.ToDateTime(reader["DOB"]);
                string gender = Convert.ToString(reader["Gender"]);
                int proPicId = 0;
                if (!(reader["ProPicId"] is DBNull))
                {
                    proPicId = Convert.ToInt32(reader["ProPicId"]);
                }
                int coverPicId = 0;
                if (!(reader["CoverPicId"] is DBNull))
                {
                    coverPicId = Convert.ToInt32(reader["CoverPicId"]);
                }
                string religion = Convert.ToString(reader["Religion"]);
                bool hasRelationship = false;
                if (!(reader["HasRelationship"] is DBNull))
                {
                    hasRelationship = Convert.ToBoolean(reader["HasRelationship"]);
                }
                string relationship = Convert.ToString(reader["Relationship"]);
                int relationshipWithId = 0;
                if (!(reader["RelationshipWithId"] is DBNull))
                {
                    relationshipWithId = Convert.ToInt32(reader["RelationshipWithId"]);
                }
                string about = Convert.ToString(reader["About"]);
                DateTime createDate = Convert.ToDateTime(reader["CreateDate"]);
                int dbUserId = Convert.ToInt32(reader["UserId"]);

                Profile profile = new Profile(id, firstName, lastName, fullName, dateOfBirth, gender, proPicId, coverPicId, religion, hasRelationship, relationship, relationshipWithId, about, createDate, dbUserId);
                profileList.Add(profile);
            }

            reader.Close();
            connection.Close();
            return profileList;
        }

        public int UpdateName(int userId, string firstName, string lastName)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET FirstName=@FirstName, LastName=@LastName WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            command.Parameters["@FirstName"].Value = firstName;

            command.Parameters.Add("@LastName", SqlDbType.VarChar);
            command.Parameters["@LastName"].Value = lastName;

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateProPicId(int userId, int proPicId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET ProPicId=@ProPicId WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@ProPicId", SqlDbType.Int);
            command.Parameters["@ProPicId"].Value = proPicId;

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateCoverPicId(int userId, int coverPicId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET CoverPicId=@CoverPicId WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@CoverPicId", SqlDbType.Int);
            command.Parameters["@CoverPicId"].Value = coverPicId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateReligion(int userId, string religion)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET Religion=@Religion WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@Religion", SqlDbType.VarChar);
            command.Parameters["@Religion"].Value = religion;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateRelationship(int userId, bool hasRelationship, string relationship, int relationshipWithId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET HasRelationship=@HasRelationship, Relationship=@Relationship, RelationshipWithId=@RelationshipWithId WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@HasRelationship", SqlDbType.Bit);
            command.Parameters["@HasRelationship"].Value = hasRelationship;

            command.Parameters.Add("@Relationship", SqlDbType.VarChar);
            command.Parameters["@Relationship"].Value = relationship;

            command.Parameters.Add("@RelationshipWithId", SqlDbType.Int);
            command.Parameters["@RelationshipWithId"].Value = relationshipWithId;

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateAbout(int userId, string about)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Profile SET About=@About WHERE UserId='" + userId + "'";
            var command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("@About", SqlDbType.VarChar);
            command.Parameters["@About"].Value = about;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
    }
}