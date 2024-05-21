using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Factories
{
    public class AddressFactory
    {
        public static TrUserAddress create(String addressID, String userID, String address, String addressName)
        {
            TrUserAddress userAddress = new TrUserAddress()
            {
                IdAddress = addressID,
                IdUser = userID,
                Address = address,
                AddressName = addressName
            };

            return userAddress;
        }
    }
}