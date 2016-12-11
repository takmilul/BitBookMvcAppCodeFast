using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class ProfileManager
    {
        ProfileGateway _profileGateway = new ProfileGateway();

        public int InsertProfile(Profile profile)
        {
            return _profileGateway.InsertProfile(profile);
        }
        public Profile GetProfileByUserId(int userId)
        {
            return _profileGateway.GetProfileByUserId(userId);
        }

        public List<Profile> GetProfileListByName(string name)
        {
            return _profileGateway.GetProfileListByName(name);
        }

        public int UpdateName(int userId, string firstName, string lastName)
        {
            return _profileGateway.UpdateName(userId, firstName, lastName);
        }

        public int UpdateProPicId(int userId, int proPicId)
        {
            return _profileGateway.UpdateProPicId(userId, proPicId);
        }

        public int UpdateCoverPicId(int userId, int coverPicId)
        {
            return _profileGateway.UpdateCoverPicId(userId, coverPicId);
        }

        public int UpdateReligion(int userId, string religion)
        {
            return _profileGateway.UpdateReligion(userId, religion);
        }

        public int UpdateRelationship(int userId, bool hasRelationship, string relationship, int relationshipWithId)
        {
            return _profileGateway.UpdateRelationship(userId, hasRelationship, relationship, relationshipWithId);
        }

        public int UpdateAbout(int userId, string about)
        {
            return _profileGateway.UpdateAbout(userId, about);
        }

    }
}