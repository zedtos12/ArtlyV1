<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="ArtlyV1.Views.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="stylesheet" href="CSS/UpdateProfilePageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="updateProfileWrapper d-flex flex-column align-items-center justify-content-center pt-5 pb-5">
        <div class="updateProfileTitle mb-3"> Update your Profile </div>

        <div class="updateProfileImageWrapper mb-2">
            <asp:Image ID="profilePictureImage" runat="server" CssClass="profilePictureImage" />
            <label class="file-upload">
                <img src="Images/Profile/UploadIcon.png" class="uploadImageIcon" />
                <asp:FileUpload ID="profilePictureImageUpload" runat="server" accept=".png,.jpg,.jpeg" />
            </label>
        </div>

        <div class="updateProfileContent d-flex flex-column align-items-center pt-3 pb-3">
            <div class="updateProfileInputWrapper d-flex flex-column mb-3">
                <asp:Label ID="userDescriptionLabel" runat="server" Text="User Description" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userDescriptionTB" TextMode="MultiLine" runat="server" placeholder="Limit: 250 characters." CssClass="updateProfileTB userDescriptionTB"></asp:TextBox>
            </div>

            <asp:Calendar ID="userDOBCalendar" runat="server" SelectedDate="<%#DateTime.Today%>"></asp:Calendar>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3 mb-5">
                <asp:Label ID="userPhoneNumberLabel" runat="server" Text="Phone Number" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userPhoneNumberTB" runat="server" placeholder="Limit: 15 digits." CssClass="updateProfileTB"></asp:TextBox>
            </div>

            <div id="alertBox" class="alert alert-danger" role="alert" runat="server" visible="false">
                <asp:Label ID="errorLabel" runat="server"></asp:Label>
            </div>

            <div id="successBox" class="alert alert-success" role="alert" runat="server" visible="false">
                <asp:Label ID="successLabel" runat="server"></asp:Label>
            </div>
            
            <asp:Button ID="updateProfileBtn" runat="server" CssClass="updateProfileBtn btn btn-outline-light" Text="Update" OnClick="updateProfileBtn_Click" />
        </div>
    </div>
</asp:Content>
