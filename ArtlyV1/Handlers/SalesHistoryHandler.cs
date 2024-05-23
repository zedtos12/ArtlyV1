using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class SalesHistoryHandler
    {
         ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<TransactionDetail> findSalesByUsername(String username)
        {
            string userId = "specificUserId"; // Replace with the specific UserId

            List<TransactionDetail> lst = (from td in db.TransactionDetails
                                     join p in db.Products on td.IdProduct equals p.IdProduct
                                     where p.IdProductOwner == userId
                                     select td).ToList();
            return lst;
        }
    }
}