using ArtlyV1.Factories;
using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class RegisterHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        private MsUser findUserUsingUsername(String username)
        {
            MsUser user = (from x in db.ActiveEntities<MsUser>() where x.UserName == username && x.IsActive == true select x).FirstOrDefault();
            return user;
        }

        private MsUser findUserUsingEmail(String email)
        {
            MsUser user = (from x in db.ActiveEntities<MsUser>() where x.Email == email && x.IsActive == true select x).FirstOrDefault();
            return user;
        }
        
        private String getRoleID()
        {
            String roleID = (from x in db.LtRoles where x.RoleName == "User" select x.IdRole).FirstOrDefault();
            return roleID;
        }

        private void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public String register(String username, String fullname, String email, String password)
        {
            if(findUserUsingUsername(username) != null)
            {
                return "Username not unique!";
            }

            if(findUserUsingEmail(email) != null)
            {
                return "Email not unique!";
            }

            MsUser user = UserFactory.create(Guid.NewGuid().ToString(), username, fullname, email, password, true, null, getRoleID().ToString(), null, 0, null, null, null);
            addUser(user);

            return "Successful";
        }

        public void SellerRegis(string idUser)
        {
            var getUser = db.MsUsers.Where(x => x.IdUser == idUser).FirstOrDefault();
            var getSellerRole = db.LtRoles.Where(x => x.RoleName == "Seller").FirstOrDefault();

            if (getUser.IdRole != getSellerRole.IdRole)
            {
                getUser.IdRole = getSellerRole.IdRole;
                db.MsUsers.AddOrUpdate(getUser);
                db.SaveChanges();
            }
        }
    }
}