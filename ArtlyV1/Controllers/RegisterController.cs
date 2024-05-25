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
        RegisterHandler registerHandler = new RegisterHandler();

        public String register(String username, String fullname, String email, String password, String retypePassword, Boolean checkboxChecked)
        {
            if(username == "" || fullname == "" || email == "" || password == "" || retypePassword == "")
            {
                return "One of the fields are missing!";
            }

            if(new EmailAddressAttribute().IsValid(email) == false || email.EndsWith(".com") != true)
            {
                return "Email is not valid!";
            }

            if(password != retypePassword)
            {
                return "Passwords are not matching!";
            }

            if(checkboxChecked == false)
            {
                return "Checkbox needs to be checked!";
            }

            return registerHandler.register(username, fullname, email, password);
        }

        public void SellerRegis(string idUser)
        {
            registerHandler.SellerRegis(idUser);
        }
    }
}