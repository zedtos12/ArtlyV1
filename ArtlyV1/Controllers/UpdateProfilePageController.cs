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

        public String updateProfile(String userID, String newUserDescription, DateTime newUserDOB, String newPhoneNumber)
        {
            if(newUserDescription.Length > 250)
            {
                return "User description has a max length of 250 characters!";
            }

            if (newUserDOB > DateTime.Now.Date)
            {
                return "Date of birth is invalid!";
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

            if(newPhoneNumber == "")
            {
                newPhoneNumber = null;
            }

            return handler.updateProfile(userID, newUserDescription, newUserDOB, newPhoneNumber);
        }
    }
}