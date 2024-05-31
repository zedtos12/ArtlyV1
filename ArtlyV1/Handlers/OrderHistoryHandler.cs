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

        public List<TransactionDetail> findOrderDetailByTransactionID(String TransactionID)
        {
            List<TransactionDetail> orderDetails = (from x in db.TransactionDetails where x.IdTransaction == TransactionID select x).ToList();
            return orderDetails;
        }

        public bool verifyUserTransaction(String UserID, String TransactionID)
        {
            MsTransaction order = (from x in db.MsTransactions where x.IdUser == UserID && x.IdTransaction == TransactionID select x).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            return true;
        }
    }
}