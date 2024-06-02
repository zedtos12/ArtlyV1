using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        DateTime? oldUserDOB;
        String oldPhoneNumber;

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
            oldUserDOB = user.DOB;
            oldPhoneNumber = user.PhoneNumber;

            if (profilePicPath == null)
            {
                profilePicPath = "Images/Profile/DefaultProfilePicture.png";
            }

            profilePictureImage.ImageUrl = profilePicPath + "?" + DateTime.Now;

            if (oldUserDOB != null)
            {
                userDOBCalendar.SelectedDate = (DateTime)oldUserDOB;
            }

            if(!IsPostBack)
            {
                userDescriptionTB.Text = oldUserDescription;
                userPhoneNumberTB.Text = oldPhoneNumber;
            }
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            if (profilePictureImageUpload.PostedFile != null)
            {
                if (profilePictureImageUpload.PostedFile.FileName.Length > 0)
                {
                    String oldImageFilePath = user.ProfilePicture;
                    String uploadImageFileExtension = Path.GetExtension(profilePictureImageUpload.FileName);

                    if (oldImageFilePath != null)
                    {
                        if (File.Exists(oldImageFilePath))
                        {
                            File.Delete(oldImageFilePath);
                        }
                    }

                    String imageFilePath = "Images/Profile/ProfilePictures/ProfilePicture-" + userID + uploadImageFileExtension;

                    profilePictureImageUpload.SaveAs(Server.MapPath("~/Views/Images/Profile/ProfilePictures/") + "ProfilePicture-" + userID + uploadImageFileExtension);
                    controller.updateProfilePicture(userID, imageFilePath);
                }
            }

            String newUserDescription = userDescriptionTB.Text;
            DateTime newUserDOB = userDOBCalendar.SelectedDate;
            String newPhoneNumber = userPhoneNumberTB.Text;

            String msg = controller.updateProfile(userID, newUserDescription, newUserDOB, newPhoneNumber);

            if (msg != "Successful")
            {
                successBox.Visible = false;
                alertBox.Visible = true;
                errorLabel.Text = msg;
                return;
            }

            alertBox.Visible = false;
            successBox.Visible = true;
            successLabel.Text = "Profile successfully updated.";
        }
    }
}