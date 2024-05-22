using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        LoginController loginController = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String username = usernameTB.Text;
            String password = passwordTB.Text;
            Boolean remember = checkbox.Checked;

            String returned = loginController.login(username, password);

            if (returned != "Successful")
            {
                alertBox.Visible = true;
                errorLabel.Text = returned;
                return;
            }

            alertBox.Visible = false;
            errorLabel.Text = null;

            String userID = loginController.getUserID(username);

            if (remember == true)
            {
                HttpCookie userCookie = new HttpCookie("user", userID);
                userCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(userCookie);
            }
                
            Session["user"] = userID;

            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}