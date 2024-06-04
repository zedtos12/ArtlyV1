<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="ArtlyV1.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Profile Edit</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="CSS/ProfileStyles.css" />
    <style>
        .container {
            background: linear-gradient(135deg, #2F2F2F, #252525, #1C1C1C);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5" style="height: 69vh">
        <div class="row profile-section" style="height: 100%">

            <div class="col-md-3 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5">
                    <img class="rounded-circle mt-5" width="150" height="150" src="https://simplyilm.com/wp-content/uploads/2017/08/temporary-profile-placeholder-1.jpg">
                    <span id="UsernameLabel" runat="server" class="font-weight-bold" style="color: white; margin-top: 15px;">Edogaru</span>
                    <span></span>
                </div>
            </div>

            <div class="col-md-5 border-right">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h4 class="text-right">Profile Settings</h4>
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-6">
                            <label class="labels" style="color: white;">Full name</label><input id="NameInput" runat="server" type="text" class="form-control" value="">
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12">
                            <label class="labels" style="color: white;">Email</label><input id="EmailInput" runat="server" type="text" class="form-control" value="">
                        </div>
                        <div class="col-md-12">
                            <label class="labels" style="color: white;">Genders</label>
                            <asp:DropDownList ID="GenderDDL" runat="server" CssClass="dropdown"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12">
                            <label class="labels" style="color: white;">Date of Birth</label>
                            <asp:TextBox ID="txtBirthdate" runat="server"
                                TextMode="Date"
                                ToolTip="Please enter your birthdate in MM/dd/yyyy format."
                                Width="150px"
                                CssClass="form-control">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="mt-5 text-center">
                        <asp:Button ID="SaveButton" runat="server" Text="Save Profile" CssClass="btn btn-primary profile-button" OnClick="SaveProfile_Click" />
                    </div>
                </div>
            </div>


            <div class="col-md-4 address-section">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center address">
                        <h4 class="text-right">Address Settings</h4>
                        <asp:Button ID="btnAddAddress" runat="server" Text="+ Address" CssClass="btn btn-primary address-button" OnClick="btnAddAddress_Click" />
                    </div>
                    <br />
                    <div class="scrollable-column mt-3">
                        <asp:Literal ID="litAddressList" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>


            <div id="addressModal" class="modal" runat="server">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Add Address</h5>
                            <asp:Button ID="btnCloseModal" runat="server" Text="&times;" CssClass="close" OnClick="btnCloseModal_Click" />
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="labels">Address Name</label>
                                <asp:TextBox ID="txtAddressName" runat="server" CssClass="form-control" placeholder="insert address name"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="labels">Address Details</label>
                                <asp:TextBox ID="txtAddressDetails" runat="server" CssClass="form-control" placeholder="insert address details"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSaveAddress" runat="server" Text="Save Address" CssClass="btn btn-primary" OnClick="btnSaveAddress_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
