using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail create(String transactionDetailID, String transactionID, String productID, int quantity, decimal unitPrice)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                IdTransactionDetail = transactionDetailID,
                IdTransaction = transactionID,
                IdProduct = productID,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            return transactionDetail;
        }
    }
}