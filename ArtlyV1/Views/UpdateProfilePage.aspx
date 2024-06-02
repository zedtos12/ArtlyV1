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
            <img class="updateProfileImage" src="<%=profilePicPath%>" />
            <img class="uploadImageIcon" src="Images/Profile/UploadIcon.png" />
        </div>

        <div class="updateProfileContent d-flex flex-column align-items-center pt-3 pb-3">
            <div class="updateProfileInputWrapper d-flex flex-column">
                <asp:Label ID="userDescriptionLabel" runat="server" Text="User Description" CssClass="updateProfileLabel"></asp:Label>
                <asp:TextBox ID="userDescriptionTB" TextMode="MultiLine" runat="server" placeholder="Limit: 250 characters." CssClass="updateProfileTB userDescriptionTB"></asp:TextBox>
            </div>

            <asp:Calendar ID="userDOBCalendar" runat="server"></asp:Calendar>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3">
                <asp:Label ID="userPhoneNumberLabel" runat="server" Text="Phone Number" CssClass="updateProfileLabel"></asp:Label>
                <asp:TextBox ID="userPhoneNumberTB" runat="server" placeholder="Limit: 15 digits." CssClass="updateProfileTB"></asp:TextBox>
            </div>
            
            <asp:Button ID="updateProfileBtn" runat="server" CssClass="btn btn-outline-light" Text="Update" />
        </div>
    </div>
</asp:Content>
