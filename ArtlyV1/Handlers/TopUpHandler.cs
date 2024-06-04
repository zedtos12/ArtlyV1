using ArtlyV1.Factories;
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

        public List<TopUp> GetTopUpsByUserID(string userID)
        {
            List<TopUp> topUps = (from x in db.TopUps where x.IdUser == userID select x).ToList();
            return topUps;
        }

        public String findUserID(String username)
        {
            String userID = (from x in db.MsUsers where x.UserName == username select x.IdUser).FirstOrDefault();
            return userID;
        }

        public void topUpUserBalance(String userID, decimal topUpBalance)
        {
            MsUser user = (from x in db.MsUsers where x.IdUser == userID select x).FirstOrDefault();
            user.Balance = user.Balance + topUpBalance;

            TopUp topUp = TopUpFactory.create(Guid.NewGuid().ToString(), userID, topUpBalance, DateTime.Now);
            db.TopUps.Add(topUp);

            db.SaveChanges();
        }
    }
}