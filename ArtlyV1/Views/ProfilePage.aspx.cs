using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        ProfilePageHandler profilePageHandler = new ProfilePageHandler();
        string userId;
        MsUser User;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Session["user"].ToString();
            User = profilePageHandler.GetUser(userId);

            UsernameLabel.InnerText = User.FullName;
            EmailLabel.InnerText = User.Email;
        }
    }
}