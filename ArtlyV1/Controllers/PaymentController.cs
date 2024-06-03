﻿using ArtlyV1.Handlers;
using ArtlyV1.Models;
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

        public List<TrUserAddress> getAddressList(String userID)
        {
            return handler.getAddressList(userID);
        }

        public String doPaymentWithoutShipping(String userID, decimal resultingBalance, List<CartItem> cart)
        {
            String usualValidationMsg = doUsualValidation(userID, resultingBalance);

            if(usualValidationMsg != "Successful")
            {
                return usualValidationMsg;
            }

            return handler.doPaymentWithoutShipping(userID, resultingBalance, cart);
        }

        public String doPaymentWithShipping(String userID, decimal resultingBalance, List<CartItem> cart, String addressName)
        {
            if(addressName == null)
            {
                return "Address not selected!";
            }

            String usualValidationMsg = doUsualValidation(userID, resultingBalance);

            if (usualValidationMsg != "Successful")
            {
                return usualValidationMsg;
            }

            String addressID = handler.findAddressID(addressName, userID);

            if(addressID == null)
            {
                return "Address not found!";
            }

            return handler.doPaymentWithShipping(userID, resultingBalance, cart, addressID);
        }
    }
}