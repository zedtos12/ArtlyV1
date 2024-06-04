using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class LoginHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        private MsUser findUser(String username)
        {
            MsUser user = (from x in db.ActiveEntities<MsUser>() where x.UserName == username select x).FirstOrDefault();
            return user;
        }

        public String login(String username, String password)
        {
            MsUser user = findUser(username);

            if(user == null)
            {
                return "Invalid username, user account not found!";
            }

            if(user.Password != password)
            {
                return "Incorrect password!";
            }

            return "Successful";
        }

        public String getUserID(String username)
        {
            return findUser(username).IdUser;
        }

        public String getUserRole(String userId)
        {
            return db.MsUsers
                .Where(x => x.IdUser == userId)
                .Select(x => x.LtRole.RoleName)
                .FirstOrDefault();
        }
    }
}