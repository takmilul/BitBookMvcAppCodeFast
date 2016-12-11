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
    public class BasicInfoGateway
    {
        private readonly string connectionString =
            WebConfigurationManager.ConnectionStrings["BitBookDBConnectionString"].ConnectionString;

        public int AddAddress(Address address)
        {
            var connection = new SqlConnection(connectionString);
            var query = "INSERT INTO Address (CurrentCity, CurrentCountry, FromCity, FromCountry, UserId) VALUES(@CurrentCity, @CurrentCountry, @FromCity, @FromCountry, @UserId)";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@CurrentCity", SqlDbType.VarChar);
            command.Parameters["@CurrentCity"].Value = address.CurrentCity;
            command.Parameters.Add("@CurrentCountry", SqlDbType.VarChar);
            command.Parameters["@CurrentCountry"].Value = address.CurrentCountry;
            command.Parameters.Add("@FromCity", SqlDbType.VarChar);
            command.Parameters["@FromCity"].Value = address.FromCity;
            command.Parameters.Add("@FromCountry", SqlDbType.VarChar);
            command.Parameters["@FromCountry"].Value = address.FromCountry;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = address.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateAddress(Address address)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Address SET CurrentCity=@CurrentCity, CurrentCountry=@CurrentCountry, FromCity=@FromCity, FromCountry=@FromCountry  WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@CurrentCity", SqlDbType.VarChar);
            command.Parameters["@CurrentCity"].Value = address.CurrentCity;
            command.Parameters.Add("@CurrentCountry", SqlDbType.VarChar);
            command.Parameters["@CurrentCountry"].Value = address.CurrentCountry;
            command.Parameters.Add("@FromCity", SqlDbType.VarChar);
            command.Parameters["@FromCity"].Value = address.FromCity;
            command.Parameters.Add("@FromCountry", SqlDbType.VarChar);
            command.Parameters["@FromCountry"].Value = address.FromCountry;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = address.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Address GetAddress(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Address WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            Address address = null;
            if (reader.Read())
            {
                address = new Address
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CurrentCity = Convert.ToString(reader["CurrentCity"]),
                    CurrentCountry = Convert.ToString(reader["CurrentCountry"]),
                    FromCity = Convert.ToString(reader["FromCity"]),
                    FromCountry = Convert.ToString(reader["FromCountry"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return address;
        }

        public int AddEducation(Education education)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddEducation";
            var command = new SqlCommand(query, connection){CommandType = CommandType.StoredProcedure};
            command.Parameters.Clear();
            command.Parameters.Add("@Institute", SqlDbType.VarChar);
            command.Parameters["@Institute"].Value = education.Institute;
            command.Parameters.Add("@FromDate", SqlDbType.Date);
            command.Parameters["@FromDate"].Value = education.FromDate;
            command.Parameters.Add("@ToDate", SqlDbType.Date);
            command.Parameters["@ToDate"].Value = education.ToDate;
            command.Parameters.Add("@HasDegree", SqlDbType.Bit);
            command.Parameters["@HasDegree"].Value = education.HasDegree;
            command.Parameters.Add("@Degree", SqlDbType.VarChar);
            command.Parameters["@Degree"].Value = education.Degree;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = education.UserId;
            connection.Open();
            int educationId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return educationId;
        }

        public int UpdateEducation(Education education)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Education SET Institute=@Institute, FromDate=@FromDate, ToDate=@ToDate, HasDegree=@HasDegree, Degree=@Degree WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Institute", SqlDbType.VarChar);
            command.Parameters["@Institute"].Value = education.Institute;
            command.Parameters.Add("@FromDate", SqlDbType.Date);
            command.Parameters["@FromDate"].Value = education.FromDate;
            command.Parameters.Add("@ToDate", SqlDbType.Date);
            command.Parameters["@ToDate"].Value = education.ToDate;
            command.Parameters.Add("@HasDegree", SqlDbType.Bit);
            command.Parameters["@HasDegree"].Value = education.HasDegree;
            command.Parameters.Add("@Degree", SqlDbType.VarChar);
            command.Parameters["@Degree"].Value = education.Degree;
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = education.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Education GetEducation(int educationId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Education WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = educationId;
            connection.Open();
            var reader = command.ExecuteReader();
            Education education = null;
            if (reader.Read())
            {
                education = new Education
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Institute = Convert.ToString(reader["Institute"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    HasDegree = Convert.ToBoolean(reader["FromCountry"]),
                    Degree = Convert.ToString(reader["Degree"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return education;
        }

        public List<Education> GetAllEducations(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Education WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<Education> educationList = new List<Education>();
            while (reader.Read())
            {
                Education education = new Education
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Institute = Convert.ToString(reader["Institute"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    HasDegree = Convert.ToBoolean(reader["FromCountry"]),
                    Degree = Convert.ToString(reader["Degree"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                educationList.Add(education);
            }
            reader.Close();
            connection.Close();
            return educationList;
        }

        public int RemoveEducation(int educationId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM Education WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = educationId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AddWork(Work work)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddWork";
            var command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@Company", SqlDbType.VarChar);
            command.Parameters["@Conpany"].Value = work.Company;
            command.Parameters.Add("@Position", SqlDbType.VarChar);
            command.Parameters["@Position"].Value = work.Position;
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = work.Description;
            command.Parameters.Add("@City", SqlDbType.VarChar);
            command.Parameters["@City"].Value = work.City;
            command.Parameters.Add("@Country", SqlDbType.VarChar);
            command.Parameters["@Country"].Value = work.Country;
            command.Parameters.Add("@FromDate", SqlDbType.Date);
            command.Parameters["@FromDate"].Value = work.FromDate;
            command.Parameters.Add("@ToDate", SqlDbType.Date);
            command.Parameters["@ToDate"].Value = work.ToDate;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = work.UserId;
            connection.Open();
            int workId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return workId;
        }

        public int UpdateWork(Work work)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Work SET Company=@Company, Position=@Position, Description=@Description, City=@City, Country=@Country, FromDate=@FromDate, ToDate=@ToDate WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Company", SqlDbType.VarChar);
            command.Parameters["@Conpany"].Value = work.Company;
            command.Parameters.Add("@Position", SqlDbType.VarChar);
            command.Parameters["@Position"].Value = work.Position;
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = work.Description;
            command.Parameters.Add("@City", SqlDbType.VarChar);
            command.Parameters["@City"].Value = work.City;
            command.Parameters.Add("@Country", SqlDbType.VarChar);
            command.Parameters["@Country"].Value = work.Country;
            command.Parameters.Add("@FromDate", SqlDbType.Date);
            command.Parameters["@FromDate"].Value = work.FromDate;
            command.Parameters.Add("@ToDate", SqlDbType.Date);
            command.Parameters["@ToDate"].Value = work.ToDate;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = work.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Work GetWork(int workId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Work WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = workId;
            connection.Open();
            var reader = command.ExecuteReader();
            Work work = null;
            if (reader.Read())
            {
                work = new Work
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Company = Convert.ToString(reader["Company"]),
                    Position = Convert.ToString(reader["Position"]),
                    Description = Convert.ToString(reader["Description"]),
                    City = Convert.ToString(reader["City"]),
                    Country = Convert.ToString(reader["Country"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return work;
        }

        public List<Work> GetAllWork(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Work WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<Work> workList = new List<Work>();
            while (reader.Read())
            {
                Work work = new Work
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Company = Convert.ToString(reader["Company"]),
                    Position = Convert.ToString(reader["Position"]),
                    Description = Convert.ToString(reader["Description"]),
                    City = Convert.ToString(reader["City"]),
                    Country = Convert.ToString(reader["Country"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                workList.Add(work);
            }
            reader.Close();
            connection.Close();
            return workList;
        }

        public int RemoveWork(int workId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM Work WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = workId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AddMobileNo(MobileNo mobileNo)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddWork";
            var command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            command.Parameters["@MobileNo"].Value = mobileNo.MobileNumber;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = mobileNo.UserId;
            connection.Open();
            int mobileNoId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return mobileNoId;
        }

        public int UpdateMobileNo(MobileNo mobileNo)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE MobileNo SET MobileNo=@MobileNo WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            command.Parameters["@MobileNo"].Value = mobileNo.MobileNumber;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = mobileNo.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public MobileNo GetMobileNo(int mobileNoId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM MobileNo WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = mobileNoId;
            connection.Open();
            var reader = command.ExecuteReader();
            MobileNo mobileNo = null;
            if (reader.Read())
            {
                mobileNo = new MobileNo
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    MobileNumber = Convert.ToString(reader["MobileNo"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return mobileNo;
        }

        public List<MobileNo> GetAllMobileNo(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM MobileNo WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<MobileNo> mobileNoList = new List<MobileNo>();
            while (reader.Read())
            {
                MobileNo mobileNo = new MobileNo
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    MobileNumber = Convert.ToString(reader["MobileNo"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                mobileNoList.Add(mobileNo);
            }
            reader.Close();
            connection.Close();
            return mobileNoList;
        }

        public int RemoveMobileNo(int mobileNoId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM MobileNo WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = mobileNoId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AddProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddProfessionalSkill";
            var command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@Skill", SqlDbType.VarChar);
            command.Parameters["@Skill"].Value = professionalSkill.Skill;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = professionalSkill.UserId;
            connection.Open();
            int professionalSkillId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return professionalSkillId;
        }

        public int UpdateProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE ProfessionalSkills SET Skill=@Skill WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Skill", SqlDbType.VarChar);
            command.Parameters["@Skill"].Value = professionalSkill.Skill;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = professionalSkill.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public ProfessionalSkill GetProfessionalSkill(int professionalSkillId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM ProfessionalSkills WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = professionalSkillId;
            connection.Open();
            var reader = command.ExecuteReader();
            ProfessionalSkill professionalSkill = null;
            if (reader.Read())
            {
                professionalSkill = new ProfessionalSkill
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Skill = Convert.ToString(reader["Skill"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return professionalSkill;
        }

        public List<ProfessionalSkill> GetAllProfessionalSkills(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM ProfessionalSkills WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<ProfessionalSkill> professionalSkillsList = new List<ProfessionalSkill>();
            while (reader.Read())
            {
                ProfessionalSkill professionalSkills = new ProfessionalSkill
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Skill = Convert.ToString(reader["Skill"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                professionalSkillsList.Add(professionalSkills);
            }
            reader.Close();
            connection.Close();
            return professionalSkillsList;
        }

        public int RemoveProfessionalSkill(int professionalSkillId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM ProfessionalSkill WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = professionalSkillId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AddInterest(Interest interest)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddInterest";
            var command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@InterestedIn", SqlDbType.VarChar);
            command.Parameters["@InterestedIn"].Value = interest.InterestedIn;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = interest.UserId;
            connection.Open();
            int interestId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return interestId;
        }

        public int UpdateInterest(Interest interest)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE Interest SET InterestedIn=@InterestedIn WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@InterestedIn", SqlDbType.VarChar);
            command.Parameters["@InterestedIn"].Value = interest.InterestedIn;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = interest.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public Interest GetInterest(int interestId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Interest WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = interestId;
            connection.Open();
            var reader = command.ExecuteReader();
            Interest interest = null;
            if (reader.Read())
            {
                interest = new Interest
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    InterestedIn = Convert.ToString(reader["InterestedIn"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return interest;
        }

        public List<Interest> GetAllInterests(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Interest WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<Interest> interestList = new List<Interest>();
            while (reader.Read())
            {
                Interest interest = new Interest
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    InterestedIn = Convert.ToString(reader["InterestedIn"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                interestList.Add(interest);
            }
            reader.Close();
            connection.Close();
            return interestList;
        }

        public int RemoveInterest(int interestId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM Interest WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = interestId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int AddFamilyMember(FamilyMember familyMember)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SP_AddInterest";
            var command = new SqlCommand(query, connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.Clear();
            command.Parameters.Add("@FamilyMemberId", SqlDbType.Int);
            command.Parameters["@FamilyMemberId"].Value = familyMember.FamilyMemberId;
            command.Parameters.Add("@Relationship", SqlDbType.VarChar);
            command.Parameters["@Relationship"].Value = familyMember.Relationship;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = familyMember.UserId;
            connection.Open();
            int familyMemberTableId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return familyMemberTableId;
        }

        public int UpdateFamilyMember(FamilyMember familyMember)
        {
            var connection = new SqlConnection(connectionString);
            var query = "UPDATE FamilyMember SET FamilyMemberId=@FamilyMemberId, Relationship=@Relationship WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@FamilyMemberId", SqlDbType.Int);
            command.Parameters["@FamilyMemberId"].Value = familyMember.FamilyMemberId;
            command.Parameters.Add("@Relationship", SqlDbType.VarChar);
            command.Parameters["@Relationship"].Value = familyMember.Relationship;
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = familyMember.UserId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public FamilyMember GetFamilyMember(int familyMemberId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM FamilyMember WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = familyMemberId;
            connection.Open();
            var reader = command.ExecuteReader();
            FamilyMember familyMember = null;
            if (reader.Read())
            {
                familyMember = new FamilyMember
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FamilyMemberId = Convert.ToInt32(reader["FamilyMemberId"]),
                    Relationship = Convert.ToString(reader["Relationship"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
            }
            reader.Close();
            connection.Close();
            return familyMember;
        }

        public List<FamilyMember> GetAllFamilyMembers(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM FamilyMember WHERE UserId=@UserId";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@UserId", SqlDbType.Int);
            command.Parameters["@UserId"].Value = userId;
            connection.Open();
            var reader = command.ExecuteReader();
            List<FamilyMember> familyMemberList = new List<FamilyMember>();
            while (reader.Read())
            {
                FamilyMember familyMember = new FamilyMember
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FamilyMemberId = Convert.ToInt32(reader["FamilyMemberId"]),
                    Relationship = Convert.ToString(reader["Relationship"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                };
                familyMemberList.Add(familyMember);
            }
            reader.Close();
            connection.Close();
            return familyMemberList;
        }

        public int RemoveFamilyMember(int id)
        {
            var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM FamilyMember WHERE Id=@Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Id", SqlDbType.Int);
            command.Parameters["@Id"].Value = id;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

    }
}