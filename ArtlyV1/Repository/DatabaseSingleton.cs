using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Repository
{
    public class DatabaseSingleton
    {
        private static ArtlyDatabaseEntities db = null;

        public static ArtlyDatabaseEntities getInstance()
        {
            if(db == null)
            {
                db = new ArtlyDatabaseEntities();
            }

            return db;
        }
    }
}