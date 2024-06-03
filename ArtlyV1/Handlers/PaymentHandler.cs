using ArtlyV1.Factories;
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

        // Status ID = On-Process
        static String statusID = "663E16D6-FDFA-4A68-9446-0A404B99BF29";

        // Payment Method ID = Artly Payment
        static String paymentMethodID = "8449E499-F9CE-44C1-98AD-8DC8C9903EC2";
        private MsUser findUserByID(String userID)
        {
            MsUser user = (from x in db.ActiveEntities<MsUser>() where x.IdUser == userID select x).FirstOrDefault();
            return user;
        }

        public String findAddressID(String addressName, String userID)
        {
            String addressID = (from x in db.ActiveEntities<TrUserAddress>() where x.IdUser == userID && x.AddressName == addressName select x.IdAddress).FirstOrDefault();
            return addressID;
        }

        public List<TrUserAddress> getAddressList(String userID)
        {
            List<TrUserAddress> addressList = (from x in db.ActiveEntities<TrUserAddress>() where x.IdUser == userID select x).ToList();
            return addressList;
        }

        private void doPayment(MsUser user, decimal resultingBalance, List<CartItem> cart, String addressID)
        {
            user.Balance = resultingBalance;
            String transactionID = Guid.NewGuid().ToString();

            MsTransaction transaction = TransactionFactory.create(transactionID, user.IdUser, DateTime.Now, statusID, paymentMethodID, Guid.NewGuid().ToString(), addressID);
            db.MsTransactions.Add(transaction);

            foreach(CartItem item in cart)
            {
                TransactionDetail transactionDetail = TransactionDetailFactory.create(Guid.NewGuid().ToString(), transactionID, item.product.IdProduct, item.qty, item.product.Price);
                db.TransactionDetails.Add(transactionDetail);

                MsUser seller = findUserByID(item.product.UserInput);
                seller.Balance = seller.Balance + (item.qty * item.product.Price);
            }

            db.SaveChanges();
        }

        public String doPaymentWithoutShipping(String userID, decimal resultingBalance, List<CartItem> cart)
        {
            MsUser user = findUserByID(userID);

            if (user == null)
            {
                return "User not found!";
            }

            doPayment(user, resultingBalance, cart, null);

            return "Successful";
        }

        public String doPaymentWithShipping(String userID, decimal resultingBalance, List<CartItem> cart, String addressID)
        {
            MsUser user = findUserByID(userID);

            if (user == null)
            {
                return "User not found!";
            }

            doPayment(user, resultingBalance, cart, addressID);

            return "Successful";
        }
    }
}