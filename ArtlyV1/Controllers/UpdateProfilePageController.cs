using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class UpdateProfilePageController
    {
        ProfilePageHandler handler = new ProfilePageHandler();

        public MsUser getUserByID(String userID)
        {
            return handler.GetUserById(userID);
        }

        public void updateProfilePicture(String userID, String imageFilePath)
        {
            handler.updateProfilePicture(userID, imageFilePath);
        }

        public String updateProfile(String userID, String newUserDescription, String newUserGenderID, String newUserDOBString, String newPhoneNumber)
        {
            DateTime? newUserDOB;

            if (newUserDOBString == "")
            {
                newUserDOB = null;
            }
            else
            {
                newUserDOB = DateTime.Parse(newUserDOBString);
            }

            if (newUserDescription.Length > 250)
            {
                return "User description has a max length of 250 characters!";
            }

            if (newPhoneNumber.Length > 15)
            {
                return "Phone number has a max length of 15 digits!";
            }

            foreach(Char c in newPhoneNumber)
            {
                if(!Char.IsDigit(c) && c != '-' && c != '(' && c != ')')
                {
                    return "Phone number is invalid!";
                }
            }

            if(newUserDescription == "")
            {
                newUserDescription = null;
            }

            if(newUserGenderID == "")
            {
                newUserGenderID = null;
            }

            if(newPhoneNumber == "")
            {
                newPhoneNumber = null;
            }

            return handler.updateProfile(userID, newUserDescription, newUserGenderID, newUserDOB, newPhoneNumber);
        }

        public List<TrUserAddress> getUserAddressList(String userID)
        {
            return handler.getAddressList(userID);
        }

        public String addAddress(String userID, String addressName, String address)
        {
            if (addressName == "" || address == "")
            {
                return "One or more fields are missing!";
            }

            return handler.insertAddress(userID, addressName, address);
        }

        public void removeAddress(String addressID)
        {
            if(addressID == null)
            {
                return;
            }

            handler.removeAddress(addressID);
        }

        public List<LtGender> getGenderList()
        {
            return handler.getGenderList();
        }
    }
}