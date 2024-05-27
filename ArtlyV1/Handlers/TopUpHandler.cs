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
    }
}