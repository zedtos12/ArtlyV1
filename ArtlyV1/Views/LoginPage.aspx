<%@ Page Title="Artly | Login" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ArtlyV1.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Artly Login Page </title>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">
<link rel="stylesheet" href="Fonts/icomoon/style.css">
<link rel="stylesheet" href="CSS/owl.carousel.min.css">
<link rel="stylesheet" href="CSS/LoginRegisterPageStyle.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	  <div class="d-lg-flex half">
  <div class="bg order-1 order-md-1" style="background-image: url('Images/bg-01.jpg');"></div>
  <div class="contents order-2 order-md-2">

    <div class="container">
      <div class="row align-items-center justify-content-center">
        <div class="col-md-7">
          <h3 class="mb-4" style="color: white;">Login</h3>
              
                <div class="form-group first">
                      <label for="username">Username</label>
                      <asp:TextBox class="form-control" ID="usernameTB" runat="server" placeholder="username"></asp:TextBox>
                </div>
                <div class="form-group last mb-3">
                    <label for="password">Password</label>
                    <asp:TextBox type="password" class="form-control" ID="passwordTB" runat="server" placeholder="password"></asp:TextBox>
                </div>

                <div class="d-flex align-items-center mb-4">
                    <label class="control control--checkbox mb-0">
                        <span class="caption"> Remember Me</span>
                        <asp:CheckBox ID="checkbox" runat="server" checked=False />
                        <div class="control__indicator"></div>
                    </label>
                </div>

                <div id="alertBox" class="alert alert-danger" role="alert" runat="server" visible="false">
                    <asp:Label ID="errorLabel" runat="server"></asp:Label>
                </div>

                <asp:Button type="submit" class="btn btn-block btn-primary" ID="submitBtn" runat="server" Text="Login" OnClick="submitBtn_Click" />
              </div>
      </div>
    </div>
  </div> 
</div>
  <script src="JS/LoginRegisterPageMain.js"></script>
</asp:Content>
