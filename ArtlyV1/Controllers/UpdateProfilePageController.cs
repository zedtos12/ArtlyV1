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
    }
}