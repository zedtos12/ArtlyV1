using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace ArtlyV1.Factories
{
    public class UserFactory
    {
        public static MsUser create(String userID, String username, String fullname, String email, String password, Boolean isActive, String genderID, String roleID, DateTime? dob, decimal balance)
        {
            MsUser user = new MsUser()
            {
                IdUser = userID,
                UserName = username,
                FullName = fullname,
                Email = email,
                Password = password,
                IsActive = isActive,
                IdGender = genderID,
                IdRole = roleID,
                DOB = dob,
                Balance = balance
            };

            return user;
        }
    }
}