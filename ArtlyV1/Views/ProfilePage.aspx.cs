﻿using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        ProfilePageHandler profileHandler = new ProfilePageHandler();
        String accessingUserID;
        MsUser accessingUser;
        String shownUserID;
        MsUser shownUser;
        public String username;
        public String profilePicPath;
        public String userDescription;
        public String userDOB;
        public String phoneNumber;
        List<MsProduct> productList;
        List<MsTransaction> transactionList;
        List<MsTransaction> sortedTransactionList;

        public Boolean isShownUserSeller()
        {
            if(shownUser.LtRole.RoleName == "Seller")
            {
                return true;
            }
            return false;
        }

        public Boolean isOwnerAccessing()
        {
            if (Request["ID"] == null)
            {
                return true;
            }
            return false;
        }

        private void refresh()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

            accessingUserID = Session["user"].ToString();
            accessingUser = profileHandler.GetUserById(accessingUserID);

            if (isOwnerAccessing())
            {
                shownUserID = accessingUserID;
                shownUser = accessingUser;
            }
            else
            {
                shownUserID = Request["ID"].ToString();
                shownUser = profileHandler.GetUserById(shownUserID);
            }

            username = shownUser.UserName;
            profilePicPath = shownUser.ProfilePicture;
            userDescription = shownUser.UserDescription;

            if (shownUser.DOB != null)
            {
                userDOB = shownUser.DOB.Value.ToString("dd-MM-yyyy");
            }

            phoneNumber = shownUser.PhoneNumber;

            Title = "Artly | " + username + "'s Profile";

            if (profilePicPath == null)
            {
                profilePicPath = "Images/Profile/DefaultProfilePicture.png";
            }

            if (userDescription == null)
            {
                userDescription = "User has no user description.";
            }

            profilePicture.ImageUrl = profilePicPath + "?" + DateTime.Now;

            if (!IsPostBack)
            {
                transactionList = profileHandler.getTransactionList(accessingUserID);
                sortedTransactionList = transactionList.OrderByDescending(transaction => transaction.OrderDate).ToList();
                userTransactionRepeater.DataSource = sortedTransactionList;
                userTransactionRepeater.DataBind();

                productList = profileHandler.getProductList(shownUserID);
                profileProductRepeater.DataSource = productList;
                profileProductRepeater.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
       }

        protected void Page_Init(object sender, EventArgs e)
        {
            refresh();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");
        }
    }
}