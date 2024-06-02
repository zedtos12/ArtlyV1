using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        UpdateProfilePageController controller = new UpdateProfilePageController();
        String userID;
        MsUser user;
        String oldUserDescription;
        public String profilePicPath;
        String oldUserDOB;
        String oldPhoneNumber;
        String newUserDescription;
        String newUserDOB;
        String newPhoneNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            userID = Session["user"].ToString();
            user = controller.getUserByID(userID);

            oldUserDescription = user.UserDescription;
            profilePicPath = user.ProfilePicture;
            oldUserDOB = user.DOB.ToString();
            oldPhoneNumber = user.PhoneNumber;

            if(profilePicPath == null)
            {
                profilePicPath = "Images/Profile/DefaultProfilePicture.png";
            }

            userDescriptionTB.Text = oldUserDescription;
            userPhoneNumberTB.Text = oldPhoneNumber;
        }
    }
}