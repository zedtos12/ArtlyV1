using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
	public partial class BecomeSeller : System.Web.UI.Page
	{
		RegisterController registerController = new RegisterController();

        protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void createButton_Click(object sender, EventArgs e)
        {
			var userId = Session["user"];
			registerController.SellerRegis(userId.ToString());
			Session["userrole"] = "Seller";
			Response.Redirect("/SellerDashboard.aspx");
        }
    }
}