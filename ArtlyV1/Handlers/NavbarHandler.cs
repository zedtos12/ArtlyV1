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

        public decimal getUserBalance(String username)
        {
            decimal balance = (from x in db.MsUsers where x.UserName == username select x.Balance).FirstOrDefault();
            return balance;
        }
    }
}