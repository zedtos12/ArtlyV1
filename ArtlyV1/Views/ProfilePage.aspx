<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="ArtlyV1.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="styles.css" />
    <style>
        .container {
            background: linear-gradient(135deg, #2F2F2F, #252525, #1C1C1C);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container mt-5 mb-5">
    <div class="row profile-section">
        <div class="col-md-3 border-right">
            <div class="d-flex flex-column align-items-center text-center p-3 py-5"><img class="rounded-circle mt-5" width="150px" src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg"><span class="font-weight-bold" color: yellow>Edogaru</span><span class="text-black-50">edogaru@mail.com.my</span><span> </span></div>
        </div>
        <div class="col-md-5 border-right">
            <div class="p-3 py-5">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h4 class="text-right">Profile Settings</h4>
                </div>
                <div class="row mt-2">

                    <div class="col-md-6"><label class="labels">Name</label><input type="text" class="form-control" placeholder="first name" value=""></div>
                    <div class="col-md-6"><label class="labels">Surname</label><input type="text" class="form-control" value="" placeholder="surname"></div>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12"><label class="labels">Mobile Number</label><input type="text" class="form-control" placeholder="enter phone number" value=""></div>
                    <div class="col-md-12"><label class="labels">Postcode</label><input type="text" class="form-control" placeholder="enter postcode" value=""></div>
                    <div class="col-md-12"><label class="labels">State</label><input type="text" class="form-control" placeholder="enter state" value=""></div>
                    <div class="col-md-12"><label class="labels">Area</label><input type="text" class="form-control" placeholder="enter area" value=""></div>
                    <div class="col-md-12"><label class="labels">Email ID</label><input type="text" class="form-control" placeholder="enter email id" value=""></div>
                    <div class="col-md-12"><label class="labels">Education</label><input type="text" class="form-control" placeholder="education" value=""></div>
                </div>
                <div class="row mt-3">
                    <div class="col-md-6"><label class="labels">Country</label><input type="text" class="form-control" placeholder="country" value=""></div>
                    <div class="col-md-6"><label class="labels">State/Region</label><input type="text" class="form-control" value="" placeholder="state"></div>
                </div>
                <div class="mt-5 text-center"><button class="btn btn-primary profile-button" type="button">Save Profile</button></div>
            </div>
        </div>
        <div class="col-md-4 address-section">
            <div class="p-3 py-5">
                <div class="d-flex justify-content-between align-items-center address"><h4 class="text-right">Profile Settings</h4>
                    <button class="btn btn-primary address-button" type="button">+ Address</button></div><br>
                <div class="col-md-12"><label class="labels">Address Name</label><input type="text" class="form-control" placeholder="insert address name" value=""></div> <br>
                <div class="col-md-12"><label class="labels">Address Details</label><input type="text" class="form-control" placeholder="insert address details" value=""></div>
                <div class="mt-5 text-center"><button class="btn btn-primary address-button" type="button">Save Address</button></div>
            </div>
            <div>
                <div class="scrollable-column mt-3">
                    <div class="address-item">
                        <div class="address-name font-weight-bold">Address Name</div>
                        <p class="address-details">123 Main St, Anytown, AT 12345</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
