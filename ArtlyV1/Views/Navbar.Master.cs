using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        NavbarHandler navbarHandler = new NavbarHandler();
        public String userRole;
        public String username;

        private void refresh()
        {
            decimal balance = 0;
            String profilePicturePath = null;

            if (Session["user"] == null && Request.Cookies["user"] != null)
            {
                Session["user"] = Request.Cookies["user"].Value;
            }

            if (Session["user"] != null)
            {
                String userID = Session["user"].ToString();
                balance = navbarHandler.getUserBalance(userID);
                userRole = navbarHandler.getUserRole(userID);
                username = navbarHandler.getUserName(userID);
                profilePicturePath = navbarHandler.getProfilePicturePath(userID);
            }

            Session["balance"] = balance;
            Session["userrole"] = userRole;

            if(profilePicturePath == null)
            {
                profilePicturePath = "Images/Navbar/AccountDefaultIcon.png";
            }

            accountImage.ImageUrl = profilePicturePath + "?" + DateTime.Now;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            refresh();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["user"];

            if (userCookie != null)
            {
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            }

            Session["user"] = null;
            Session["userrole"] = null;

            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}