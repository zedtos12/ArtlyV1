using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class OrderHistoryHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<MsTransaction> findOrdersByUserID(String UserID)
        {
            List<MsTransaction> orders = (from x in db.MsTransactions where x.IdUser == UserID select x).ToList();
            return orders;
        }
    }
}