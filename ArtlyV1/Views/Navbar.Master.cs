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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Label1.Text = "pressed";

            HttpCookie userCookie = Request.Cookies["user"];

            if(userCookie != null)
            {
                Label1.Text = userCookie.Name;
                userCookie.Expires = DateTime.Now.AddDays(-1);
            }

            Session["user"] = null;

            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}