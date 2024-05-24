using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class LoginController
    {
        LoginHandler loginHandler = new LoginHandler();

        public String login(String username, String password)
        {
            if(username == "" || password == "")
            {
                return "One of the fields are missing!";
            }

            return loginHandler.login(username, password);
        }

        public String getUserID(String username)
        {
            return loginHandler.getUserID(username);
        }

        public String getUserRole(string userId)
        {
            return loginHandler.getUserRole(userId);
        }
    }
}