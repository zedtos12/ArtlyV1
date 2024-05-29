using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class PaymentHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public String doPaymentWithoutShipping(String userID, decimal resultingBalance)
        {
            
        }

        public String doPaymentWithShipping(String userID, decimal resultingBalance, String shippingAddress, String shippingCountry, String shippingCity, String shippingZip)
        {
            
        }
    }
}