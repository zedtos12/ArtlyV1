using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private RegisterController registerController = new RegisterController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String username = usernameTB.Text;
            String fullname = fullnameTB.Text;
            String email = emailTB.Text;
            String password = passwordTB.Text;
            String retypePassword = retypePasswordTB.Text;
            Boolean checkboxChecked = checkbox.Checked;

            String returned = registerController.register(username, fullname, email, password, retypePassword, checkboxChecked);

            if (returned != "Successful")
            {
                alertBox.Visible = true;
                errorLabel.Text = returned;
                return;
            }

            alertBox.Visible = false;
            errorLabel.Text = null;

            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}