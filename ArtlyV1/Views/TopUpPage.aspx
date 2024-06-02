<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TopUpPage.aspx.cs" Inherits="ArtlyV1.Views.TopUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/TopUpPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="topUpWrapper d-flex flex-column align-items-center justify-content-center">
        <div class="topUpTitle mb-3"> Top Up a User</div>
        <div class="topUpContent d-flex flex-column pt-3 pb-3 align-items-center">
            <div class="topUpInputWrapper mb-3 d-flex flex-column">
                <asp:Label ID="topUpUsernameLabel" runat="server" Text="Username" class="topUpLabel mr-3"></asp:Label>
                <asp:TextBox ID="topUpUsernameTB" runat="server" placeholder="Username of user here..." class="topUpTB" OnTextChanged="topUpUsernameTB_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

            <div class="topUpInputWrapper d-flex flex-column">
                <asp:Label ID="topUpUserIDLabel" runat="server" Text="UserID" class="topUpLabel mr-3"></asp:Label>
                <asp:TextBox ID="topUpUserIDTB" runat="server" placeholder="User not found" class="topUpTB" ReadOnly="true"></asp:TextBox>
            </div>

            <% if (isUserFound())
            { %>
                <div class="topUpInputWrapper d-flex flex-column mt-3">
                    <asp:Label ID="topUpBalanceLabel" runat="server" Text="Top Up Balance" class="topUpLabel mr-3"></asp:Label>
                    <div class="topUpBalanceWrapper d-flex align-items-center">
                        IDR
                        <asp:TextBox ID="topUpBalanceTB" runat="server" placeholder="Top up balance here..." class="topUpTB ml-2"></asp:TextBox>
                    </div>
                </div>

                <div id="alertBox" class="alert alert-danger mt-3" role="alert" runat="server" visible="false">
                    <asp:Label ID="errorLabel" runat="server"></asp:Label>
                </div>

                <div id="successBox" class="alert alert-success mt-3" role="alert" runat="server" visible="false">
                    <asp:Label ID="successLabel" runat="server"></asp:Label>
                </div>

                <asp:Button ID="topUpBtn" runat="server" Text="Top up" class="btn btn-outline-light mt-3" OnClick="topUpBtn_Click" />
            <% } %>
        </div>
    </div>
</asp:Content>
