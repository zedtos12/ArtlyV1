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
        public decimal balance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user"] != null)
            {
                Session["user"] = Request.Cookies["user"].Value;
            }

            if (Session["user"] != null)
            {
                balance = navbarHandler.getUserBalance(Session["user"].ToString());
                Session["balance"] = balance;
            }
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