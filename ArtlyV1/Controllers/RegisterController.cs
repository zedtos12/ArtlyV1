using ArtlyV1.Factories;
using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class RegisterController
    {
        private RegisterHandler registerHandler = new RegisterHandler();

        public String register(String username, String fullname, String email, String password, String retypePassword)
        {
            if(username == null || fullname == null || email == null || password == null || retypePassword == null )
            {
                return "One of the fields are missing!";
            }

            if(new EmailAddressAttribute().IsValid(email) == false)
            {
                return "Email is not valid!";
            }

            if(password != retypePassword)
            {
                return "Passwords are not matching!";
            }

            return registerHandler.register(username, fullname, email, password);
        }
    }
}