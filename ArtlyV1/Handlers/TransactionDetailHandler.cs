using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class TransactionDetailHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<TransactionDetail> getTransactionDetailList(String transactionID)
        {
            List<TransactionDetail> transactionDetailList = (from x in db.TransactionDetails where x.IdTransaction == transactionID select x).ToList();
            return transactionDetailList;
        }
    }
}