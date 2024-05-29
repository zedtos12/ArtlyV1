using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class TopUpHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public String findUserID(String username)
        {
            String userID = (from x in db.MsUsers where x.UserName == username select x.IdUser).FirstOrDefault();
            return userID;
        }

        public void topUpUserBalance(String userID, decimal topUpBalance)
        {
            MsUser user = (from x in db.MsUsers where x.IdUser == userID select x).FirstOrDefault();
            user.Balance = user.Balance + topUpBalance;

            db.SaveChanges();
        }
    }
}