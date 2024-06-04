using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        UpdateProfilePageController controller = new UpdateProfilePageController();
        String userID;
        MsUser user;
        String oldUserDescription;
        String oldGenderID;
        public String profilePicPath;
        DateTime? oldUserDOB;
        String oldPhoneNumber;
        List<LtGender> genderList;
        List<TrUserAddress> addressList;
 
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
            oldGenderID = user.IdGender;
            oldUserDOB = user.DOB;
            oldPhoneNumber = user.PhoneNumber;

            if (profilePicPath == null)
            {
                profilePicPath = "Images/Profile/DefaultProfilePicture.png";
            }

            profilePictureImage.ImageUrl = profilePicPath + "?" + DateTime.Now;

            if (!IsPostBack)
            {
                userDescriptionTB.Text = oldUserDescription;
                userPhoneNumberTB.Text = oldPhoneNumber;

                if(oldUserDOB != null)
                {
                    userDOBTB.Text = oldUserDOB.Value.ToString("yyyy-MM-dd");
                }

                genderList = controller.getGenderList();

                List<ListItem> RBList = new List<ListItem>();

                foreach (LtGender gender in genderList)
                {
                    ListItem RB = new ListItem()
                    {
                        Value = gender.IdGender,
                        Text = gender.GenderName
                    };

                    RBList.Add(RB);
                }

                userGenderRBList.DataValueField = "Value";
                userGenderRBList.DataTextField = "Text";
                userGenderRBList.DataSource = RBList;
                userGenderRBList.DataBind();

                refreshAddressRepeater();
            }

            if(oldGenderID != null)
            {
                userGenderRBList.Items.FindByValue(oldGenderID).Selected = true;
            }

            if (IsPostBack && profilePictureImageUpload.HasFile)
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
            }
        }

        private void refreshAddressRepeater()
        {
            addressList = controller.getUserAddressList(userID);
            addressRepeater.DataSource = addressList;
            addressRepeater.DataBind();
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            
            String newUserDescription = userDescriptionTB.Text;
            String newUserGenderID = userGenderRBList.SelectedValue;
            String newPhoneNumber = userPhoneNumberTB.Text;
            String newUserDOB = userDOBTB.Text;

            String msg = controller.updateProfile(userID, newUserDescription, newUserGenderID, newUserDOB, newPhoneNumber);

            if (msg != "Successful")
            {
                updateProfileSuccessBox.Visible = false;
                updateProfileAlertBox.Visible = true;
                updateProfileErrorLabel.Text = msg;
                return;
            }

            updateProfileAlertBox.Visible = false;
            updateProfileSuccessBox.Visible = true;
            updateProfileSuccessLabel.Text = "Profile successfully updated.";
        }

        protected void addUserAddressBtn_Click(object sender, EventArgs e)
        {
            String addressName = userAddressNameTB.Text;
            String address = userAddressTB.Text;

            String msg = controller.addAddress(userID, addressName, address);

            if(msg != "Successful")
            {
                addAddressSuccessBox.Visible = false;
                addAddressAlertBox.Visible = true;
                addAddressErrorLabel.Text = msg;
                return;
            }

            addAddressAlertBox.Visible = false;
            addAddressSuccessBox.Visible = true;
            addAddressSuccessLabel.Text = String.Format("Address '{0}' successfully added.", addressName);
            refreshAddressRepeater();
        }

        protected void removeUserAddressBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String addressID = btn.CommandArgument.ToString();

            controller.removeAddress(addressID);
            refreshAddressRepeater();
        }
    }
}