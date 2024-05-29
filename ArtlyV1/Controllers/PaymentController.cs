using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class PaymentController
    {
        PaymentHandler handler = new PaymentHandler();

        private String doUsualValidation(String userID, decimal resultingBalance)
        {
            if (userID == null)
            {
                return "User not found!";
            }

            if (resultingBalance < 0)
            {
                return "Resulting balance less than 0!";
            }

            return "Successful";
        }
        public String doPaymentWithoutShipping(String userID, decimal resultingBalance)
        {
            String usualValidationMsg = doUsualValidation(userID, resultingBalance);

            if(usualValidationMsg != "Successful")
            {
                return usualValidationMsg;
            }

            return handler.doPaymentWithoutShipping(userID, resultingBalance);
        }

        public String doPaymentWithShipping(String userID, decimal resultingBalance, String shippingAddress, String shippingCountry, String shippingCity, String shippingZip)
        {
            if(shippingAddress == "" || shippingCity == "" || shippingCountry == "" || shippingZip == "")
            {
                return "One of the fields are empty!";
            }

            String usualValidationMsg = doUsualValidation(userID, resultingBalance);

            if (usualValidationMsg != "Successful")
            {
                return usualValidationMsg;
            }

            return handler.doPaymentWithShipping(userID, resultingBalance, shippingAddress, shippingCountry, shippingCity, shippingZip);
        }
    }
}