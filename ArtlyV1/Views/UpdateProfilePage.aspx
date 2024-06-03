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
            <div class="profilePictureContainer d-flex justify-content-center align-items-center">
               <asp:Image ID="profilePictureImage" runat="server" CssClass="profilePictureImage" />
            </div>
            <label class="file-upload">
                <img src="Images/Profile/UploadIcon.png" class="uploadImageIcon" />
                <asp:FileUpload ID="profilePictureImageUpload" onchange="this.form.submit()" runat="server" accept=".png,.jpg,.jpeg" />
            </label>
        </div>

        <div class="updateProfileContent d-flex flex-column align-items-center pt-3 pb-3">
            <div class="updateProfileInputWrapper d-flex flex-column">
                <asp:Label ID="userDescriptionLabel" runat="server" Text="User Description" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userDescriptionTB" TextMode="MultiLine" runat="server" placeholder="Limit: 250 characters." CssClass="updateProfileTB userDescriptionTB"></asp:TextBox>
            </div>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3">
                <asp:Label ID="userGenderLabel" runat="server" Text="Gender" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:RadioButtonList ID="userGenderRBList" runat="server" CssClass="userGenderRBList ml-3">
                </asp:RadioButtonList>
            </div>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3">
                <asp:Label ID="userDOBLabel" runat="server" Text="Date of Birth" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userDOBTB" runat="server" TextMode="Date" ToolTip="Please enter your birthdate in MM/dd/yyyy format." CssClass="updateProfileTB userDOBTB"></asp:TextBox>
            </div>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3">
                <asp:Label ID="userPhoneNumberLabel" runat="server" Text="Phone Number" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userPhoneNumberTB" runat="server" placeholder="Limit: 15 digits." CssClass="updateProfileTB"></asp:TextBox>
            </div>

            <div id="updateProfileAlertBox" class="alert alert-danger mt-3" role="alert" runat="server" visible="false">
                <asp:Label ID="updateProfileErrorLabel" runat="server"></asp:Label>
            </div>

            <div id="updateProfileSuccessBox" class="alert alert-success mt-3" role="alert" runat="server" visible="false">
                <asp:Label ID="updateProfileSuccessLabel" runat="server"></asp:Label>
            </div>
            
            <asp:Button ID="updateProfileBtn" runat="server" CssClass="updateProfileBtn btn btn-outline-light mt-3" Text="Update" OnClick="updateProfileBtn_Click" />
        </div>

        <div class="addressContent d-flex flex-column align-items-center mt-3">
            <div class="addressTitle mb-3"> Your Addresses </div>

            <asp:Repeater ID="addressRepeater" runat="server">
                <ItemTemplate>
                    <div class="addressWrapper d-flex mb-3 justify-content-between align-items-center pl-2 pr-3">
                        <div class="userAddressContent d-flex align-items-center">
                            <img src="Images/Profile/AddressIcon.png" class="addressIcon" />

                            <div class="userAddressText ml-2">
                                <div class="userAddressName"><%#Eval("AddressName")%></div>
                                <div class="userAddress"><%#Eval("Address")%></div>
                            </div>
                        </div>

                        <asp:Button ID="removeUserAddressBtn" runat="server" Text="Remove" CssClass="removeUserAddressBtn btn" OnClick="removeUserAddressBtn_Click" CommandArgument='<%#Eval("IdAddress")%>'/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="addAddressTitle"> Add new Address </div>

            <div class="updateProfileInputWrapper d-flex flex-column">
                <asp:Label ID="userAddressNameLabel" runat="server" Text="Address Name" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userAddressNameTB" runat="server" placeholder="Limit: 50 characters." CssClass="updateProfileTB"></asp:TextBox>
            </div>

            <div class="updateProfileInputWrapper d-flex flex-column mt-3">
                <asp:Label ID="userAddressLabel" runat="server" Text="Address" CssClass="updateProfileLabel mb-1"></asp:Label>
                <asp:TextBox ID="userAddressTB" runat="server" placeholder="Include city, country and zipcode." CssClass="updateProfileTB"></asp:TextBox>
            </div>

            <div id="addAddressAlertBox" class="alert alert-danger mt-3" role="alert" runat="server" visible="false">
                <asp:Label ID="addAddressErrorLabel" runat="server"></asp:Label>
            </div>

            <div id="addAddressSuccessBox" class="alert alert-success mt-3" role="alert" runat="server" visible="false">
                <asp:Label ID="addAddressSuccessLabel" runat="server"></asp:Label>
            </div>

            <asp:Button ID="addUserAddressBtn" runat="server" CssClass="addUserAddressBtn btn btn-outline-light mt-3" Text="Add Address" OnClick="addUserAddressBtn_Click" />
        </div>
    </div>
</asp:Content>
