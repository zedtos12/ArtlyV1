using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class NavbarHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public decimal getUserBalance(String userID)
        {
            decimal balance = (from x in db.MsUsers where x.IdUser == userID select x.Balance).FirstOrDefault();
            return balance;
        }

        public String getUserRole(String userID)
        {
            String userRole = (from x in db.MsUsers where x.IdUser == userID select x.LtRole.RoleName).FirstOrDefault();
            return userRole;
        }

        public String getUserName(String userID)
        {
            String username = (from x in db.MsUsers where x.IdUser == userID select x.UserName).FirstOrDefault();
            return username;
        }

        public String getProfilePicturePath(String userID)
        {
            String profilePicturePath = (from x in db.MsUsers where x.IdUser == userID select x.ProfilePicture).FirstOrDefault();
            return profilePicturePath;
        }
    }
}