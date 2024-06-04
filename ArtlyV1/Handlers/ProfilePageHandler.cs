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

        public List<TrUserAddress> GetAddressByUserId(String userID)
        {
            List<TrUserAddress> userAddresses = (from x in db.TrUserAddresses where x.IdUser == userID select x).ToList();
            return userAddresses;
        }

        public String insertAddress(String userID, String addressName, String address)
        {
            if (findDuplicateAddressName(userID, addressName))
            {
                return "Address name already exists!";
            }

            TrUserAddress NewAddress = AddressFactory.create(Guid.NewGuid().ToString(), userID, address, addressName);
            db.TrUserAddresses.Add(NewAddress);
            db.SaveChanges();

            return "Successful";
        }

        public MsUser GetUserById(string userID)
        {
            return (from x in db.ActiveEntities<MsUser>() where x.IdUser == userID select x).FirstOrDefault();
        }

        public List<MsProduct> getProductList(string userID)
        {
            List<MsProduct> productList = (from x in db.ActiveEntities<MsProduct>() where x.UserInput == userID select x).ToList();
            return productList;
        }

        public void updateProfilePicture(String userID, String imageFilePath)
        {
            MsUser user = GetUserById(userID);

            if(user == null)
            {
                return;
            }

            user.ProfilePicture = imageFilePath;
            db.SaveChanges();
        }

        public String updateProfile(String userID, String newUserDescription, String newUserGenderID, DateTime? newUserDOB, String newPhoneNumber)
        {
            MsUser user = GetUserById(userID);
            
            if(user == null)
            {
                return "User not found!";
            }

            user.UserDescription = newUserDescription;
            user.IdGender = newUserGenderID;
            user.DOB = newUserDOB;
            user.PhoneNumber = newPhoneNumber;
            db.SaveChanges();

            return "Successful";
        }

        public void removeAddress(String addressID)
        {
            TrUserAddress address = (from x in db.TrUserAddresses where x.IdAddress == addressID select x).FirstOrDefault();
            db.TrUserAddresses.Remove(address);
            db.SaveChanges();
        }

        public List<LtGender> getGenderList()
        {
            List<LtGender> genderList = (from x in db.LtGenders select x).ToList();
            return genderList;
        }

        public List<MsTransaction> getTransactionList(String userID)
        {
            List<MsTransaction> transactionList = (from x in db.MsTransactions where x.IdUser == userID select x).ToList();
            return transactionList;
        }

        public List<TrUserAddress> getAddressList(String userID)
        {
            List<TrUserAddress> addressList = (from x in db.TrUserAddresses where x.IdUser == userID select x).ToList();
            return addressList;
        }

        public void UpdateUser(string userID, string fullName, DateTime dateTime, string GenderID)
        {
            MsUser user = (from x in db.MsUsers where x.IdUser == userID select x).FirstOrDefault();
            user.FullName = fullName;
            user.DOB = dateTime;
            user.IdGender = GenderID;
            db.SaveChanges();
        }

        public List<string> GetGenderName()
        {
            return (from x in db.LtGenders select x.GenderName).ToList();
        }

        public List<LtGender> GetGenders()
        {
            return (from x in db.LtGenders select x).ToList();
        }       

        public string GetGenderIDByName(string genderName)
        {
            return (from x in db.LtGenders where x.GenderName == genderName select x.IdGender).FirstOrDefault();
        }
    }
}