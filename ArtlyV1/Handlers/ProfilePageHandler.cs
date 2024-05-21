using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class ProfilePageHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

      

        public List<TrUserAddress> GetTrUserAddresses(String userID)
        {
            List<TrUserAddress> userAddresses = (from x in db.TrUserAddresses where x.IdUser == userID select x).ToList();
            return userAddresses;
        }
    }
}