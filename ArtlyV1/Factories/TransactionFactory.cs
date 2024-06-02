using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Factories
{
    public class TransactionFactory
    {
        public static MsTransaction create(String transactionID, String userID, DateTime orderDate, String statusID, String paymentMethodID, String trackingID)
        {
            MsTransaction transaction = new MsTransaction()
            {
                IdTransaction = transactionID,
                IdUser = userID,
                OrderDate = orderDate,
                IdStatus = statusID,
                IdPaymentMethod = paymentMethodID,
                TrackingId = trackingID
            };

            return transaction;
        }
    }
}