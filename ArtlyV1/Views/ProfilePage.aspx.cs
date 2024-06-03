using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        ProfilePageHandler profileHandler = new ProfilePageHandler();
        string userId;
        MsUser User;
        List<string> genderNames = new List<string>();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("loginpage.aspx");
            //}

            //userId = Session["user"].ToString();
            userId = "1f6a9ad8-520a-4e75-9e71-e086697d563c";
            User = profileHandler.GetUserById(userId);

            UsernameLabel.InnerText = User.UserName;

            EmailInput.Value = User.Email;
            NameInput.Value = User.FullName;

            genderNames = profileHandler.GetGenderName();
            genderNames.Insert(0, "select gender");

            if (!IsPostBack)
            {
                GenderDDL.DataSource = genderNames;
                GenderDDL.DataBind();
            }

            if (User.IdGender != null)
            {
                GenderDDL.SelectedValue = User.LtGender.GenderName;
            }

            LoadAddressList();
        }

        protected void SaveProfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OKE");
            string fullName = NameInput.Value;
            DateTime dob = DateTime.Parse(NameInput.Value);

            string genderName = GenderDDL.SelectedValue;
            string genderID = profileHandler.GetGenderIDByName(genderName);

            profileHandler.UpdateUser(userId, fullName, dob, genderID);
            
        }     

        protected void btnSaveAddress_Click(object sender, EventArgs e)
        {
            string addressName = txtAddressName.Text.Trim();
            string addressDetails = txtAddressDetails.Text.Trim();

            if (!string.IsNullOrEmpty(addressName) && !string.IsNullOrEmpty(addressDetails))
            {
                string result = profileHandler.insertAddress(userId, addressDetails, addressName);
                Response.Write("<script>alert('" + result + "')</script>");
                txtAddressName.Text = string.Empty;
                txtAddressDetails.Text = string.Empty;
                addressModal.Style.Add("display", "none");
            }
            else
            {
                Response.Write("<script>alert('Address name and detail must not be empty')</script>");
            }
            LoadAddressList();
        }

        public void LoadAddressList()
        {
            List<TrUserAddress> addresses = profileHandler.GetAddressByUserId(userId);
            StringBuilder addressListHTML = new StringBuilder();

            foreach (TrUserAddress address in addresses)
            {
                addressListHTML.Append("<div class='address-item'>");
                addressListHTML.Append($"<div class='address-name font-weight-bold'>{address.AddressName}</div>");
                addressListHTML.Append($"<p class='address-details'>{address.Address}</p>");
                addressListHTML.Append("</div>");

                System.Diagnostics.Debug.WriteLine(address.AddressName);
            }

            litAddressList.Text = addressListHTML.ToString();
        }

        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            addressModal.Style.Add("display", "block");
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            addressModal.Style.Add("display", "none");
        }
    }
}