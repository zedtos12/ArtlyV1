using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Factories
{
    public class TopUpFactory
    {
        public static TopUp create(String topUpID, String userID, decimal amount, DateTime date)
        {
            TopUp topUp = new TopUp()
            {
                IdTopUp = topUpID,
                IdUser = userID,
                Amount = amount,
                TopUpDate = date
            };

            return topUp;
        }
    }
}