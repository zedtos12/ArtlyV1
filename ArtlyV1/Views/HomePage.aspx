<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ArtlyV1.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Artly </title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="Fonts/icomoon/style.css">
    <link rel="stylesheet" href="CSS/HomePageStyle.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="lg d-flex half">
        <div class="stack order-1 order-md-1 d-flex">
            <img class="stackFirst" src="Images/HomePage/StackFirstImage.png" />
            <img class="stackSecond" src="Images/HomePage/StackSecondImage.png"/>
            <img class="stackThird" src="Images/HomePage/StackThirdImage.png"/>
            <img class="stackFourth" src="Images/HomePage/StackFourthImage.png"/>
        </div>
        <div class="contentWrapper order-2 order-md-2 d-flex flex-column justify-content-center align-items-center">
            <div class="content">
                <div class="contentTitle"> 
                    <span class="contentHighlight"> Creativity </span>meets<span class="contentHighlight"> Convenience</span>.
                </div>
                <div class="contentText mt-2 mb-3">
                    Find and commission the art of your dreams. <br />
                    Upload artworks of your very own. <br />
                    Do it all with Artly.
                </div>
                <%if (Session["user"] == null)
                { %>
                    <asp:Button ID="getStartedBtn" CssClass="contentBtn" runat="server" Text="Get Started" OnClick="getStartedBtn_Click"/>
                <% } %>
            </div>
        </div>
    </div>
    <div class="topSeller d-flex flex-column align-items-center">
        <div class="topSellerTitle mb-3">
            Our
            <span class="topSellerHighlight"> Top </span>
            Picks
        </div>
        <div class="topSellerBorder mt-3 mb-5 d-flex flex-column align-items-center justify-content-center">
            <div class="topSellerBorderLineSM"></div>
            <div class="topSellerBorderLineMD"></div>
            <div class="topSellerBorderLineLG"></div>
        </div>
        <div class="topSellerCarousel owl-carousel mt-3">
            <asp:Repeater ID="topSellerRepeater" runat="server">
                <ItemTemplate>
                    <div>
                        <asp:Image ID="topSellerImage" runat="server" ImageUrl='<%# Container.DataItem %>'/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="topSellerBorder mt-3 mb-5 d-flex flex-column align-items-center justify-content-center">
            <div class="topSellerBorderLineLG"></div>
            <div class="topSellerBorderLineMD"></div>
            <div class="topSellerBorderLineSM"></div>
        </div>
    </div>

    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White"></asp:Label>

    <script src="JS/jquery-3.3.1.min.js"></script>
    <script defer src="JS/owl.carousel.min.js"></script>
    <script src="JS/HomePageMain.js"></script>
</asp:Content>
