using ArtlyV1.Factories;
using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class ProfilePageHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public bool findDuplicateAddressName(String userID, String addressName)
        {
            TrUserAddress userAddress = (from x in db.TrUserAddresses where x.IdUser == userID && x.AddressName == addressName select x).FirstOrDefault();
            return userAddress != null;
        }

        public List<TrUserAddress> getTrUserAddresses(String userID)
        {
            List<TrUserAddress> userAddresses = (from x in db.TrUserAddresses where x.IdUser == userID select x).ToList();
            return userAddresses;
        }

        public string insertAddress(string userID, string address, string addressName)
        {
            if (findDuplicateAddressName(userID, addressName))
            {
                return "Address name already exists!";
            }

            TrUserAddress NewAddress = AddressFactory.create(Guid.NewGuid().ToString(), userID, address, addressName);
            db.TrUserAddresses.Add(NewAddress);
            db.SaveChanges();

            return "Success";
        }

        public MsUser GetUserById(string userID)
        {
            return (from x in db.MsUsers where x.IdUser == userID select x).FirstOrDefault();
        }
    }
}