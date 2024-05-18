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

        public List<String> testList = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            testList.Add("test1");
            testList.Add("test2");
            testList.Add("test3");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["user"];

            if (userCookie != null)
            {
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            }

            Session["user"] = null;

            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}