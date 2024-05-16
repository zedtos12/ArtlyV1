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
        public static MsUser create(String username, String fullname, String email, String password)
        {
            MsUser user = new MsUser()
            {
                UserName = username,
                FullName = fullname,
                Email = email,
                Password = password,
                
            };

            return user;
        }
    }
}