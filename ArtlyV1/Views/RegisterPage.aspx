<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ArtlyV1.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Artly Register Page </title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="Fonts/icomoon/style.css">

    <link rel="stylesheet" href="CSS/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    
    <!-- Style -->
    <link rel="stylesheet" href="CSS/LoginRegisterPageStyle.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('Images/RegisterPageImage.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3 class="mb-4" style="color: white;">Sign Up</h3>
                
                  <div class="form-group first">
                        <label for="username">Username</label>
                        <asp:TextBox class="form-control" ID="usernameTB" runat="server" placeholder="e.g johnsmith"></asp:TextBox>
                  </div>
                  <div class="form-group">
                        <label for="fullname">Full Name</label>
                        <asp:TextBox class="form-control" ID="fullnameTB" runat="server" placeholder="e.g John Smith"></asp:TextBox>
                </div>
                  <div class="form-group">
                      <label for="email">Email</label>
                      <asp:TextBox type="email" class="form-control" ID="emailTB" runat="server" placeholder="your-email@gmail.com"></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <label for="password">Password</label>
                      <asp:TextBox type="password" class="form-control" ID="passwordTB" runat="server" placeholder="Your Password"></asp:TextBox>
                  </div>
                  <div class="form-group last mb-3">
                      <label for="retype-password">Re-type Password</label>
                      <asp:TextBox type="password" class="form-control" ID="retypePasswordTB" runat="server" placeholder="Re-Type Your Password"></asp:TextBox>
                  </div>

                  <div class="d-flex align-items-center mb-3">
                      <label class="control control--checkbox mb-0">
                          <span class="caption">Creating an account means you're okay with our <a href="#">Terms and Conditions</a> and our <a href="#">Privacy Policy</a>.</span>
                          <asp:CheckBox ID="checkbox" runat="server" checked=True />
                          <div class="control__indicator"></div>
                      </label>
                  </div>

                  <div id="alertBox" class="alert alert-danger" role="alert" runat="server" visible="false">
                      <asp:Label ID="errorLabel" runat="server"></asp:Label>
                  </div>

                  <asp:Button type="submit" class="btn btn-block btn-primary" ID="submitBtn" runat="server" Text="Register" OnClick="submitBtn_Click" />
                </div>
        </div>
      </div>
    </div> 
  </div>
    <script src="JS/LoginRegisterPageMain.js"></script>
</asp:Content>
