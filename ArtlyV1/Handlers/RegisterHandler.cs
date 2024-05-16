using ArtlyV1.Factories;
using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class RegisterHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        private async Task<MsUser> findUserUsingUsername(String username)
        {
            MsUser user = await (from x in db.MsUsers where x.UserName == username select x).FirstOrDefaultAsync();
            return user;
        }

        private async Task<MsUser> findUserUsingEmail(String email)
        {
            MsUser user = await (from x in db.MsUsers where x.Email == email select x).FirstOrDefaultAsync();
            return user;
        }

        private void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChangesAsync();
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

            MsUser user = UserFactory.create(username, fullname, email, password);

            user.IsActive = true;
            user.IdGender = null;
            user.DOB = null;

            return "Successful";
        }
    }
}