<%@ Page Title="" Language="C#" MasterPageFile="~/Views/SellerDashboard.Master" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="ArtlyV1.Views.AddProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/AddProductStyle.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid m-3 p-3">
        <div class="row">
            <p class="text-white font-weight-bold" style="font-size:1.5rem">Add Product</p>
        </div>
        <div class="row d-flex justify-content-center align-items-center mt-5">
            <div class="container d-flex">
                <div class="preview">
                    <asp:Image ID="productImage" runat="server" CssClass="productImage" />
                    <asp:FileUpload ID="productImageUpload" runat="server" CssClass="productImageUpload mt-3" />
                </div>
                <div style="width: 10%">
                </div>
                <div class="d-flex flex-column formAdd">
                    <div class="d-flex flex-column basic-information">
                        <div class="d-flex flex-column">
                            <asp:Label runat="server" Text="Product Name" CssClass="text textLabel"></asp:Label>
                            <asp:TextBox ID="productName" runat="server" CssClass="productName form-item p-2 mt-2 mb-4" placeholder="Eg-Artly"></asp:TextBox>
                        </div>
                        <div  class="d-flex flex-column">
                            <asp:Label runat="server" Text="Product Description" CssClass="text textLabel"></asp:Label>
                            <asp:TextBox ID="productDescription" runat="server" CssClass="productDescription form-item p-2 mt-2 mb-4" placeholder="Product Description"></asp:TextBox>
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label runat="server" Text="Product Price" CssClass="text textLabel"></asp:Label>
                            <asp:TextBox ID="productPrice" runat="server" CssClass="productPrice form-item p-2 mt-2 mb-4" placeholder="Product Price"></asp:TextBox>
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label runat="server" Text="Stock" CssClass="text textLabel"></asp:Label>
                            <asp:TextBox ID="productStock" runat="server" CssClass="stock form-item p-2 mt-2 mb-4" placeholder="0-999"></asp:TextBox>
                        </div>
                        <div class="typeContainer d-flex flex-column">
                            <asp:Label ID="typeLabel" runat="server" Text="Type" CssClass="typeLabelcss textLabel mb-1"></asp:Label>
                            <asp:RadioButtonList ID="typeList" runat="server" CssClass="typeListcss ml-3">
                            </asp:RadioButtonList>
                        </div>
                        <div class="categoryContainer d-flex flex-column">
                            <asp:Label ID="categoryLabel" runat="server" Text="Category" CssClass="textLabel mb-1"></asp:Label>
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="dropdown mb-3 btn btn-warning">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Label ID="ErrorLabel" runat="server" CssClass="error-text"></asp:Label>
                    <asp:Button ID="addProductBtn" runat="server" CssClass="btn btn-warning form-item p-2 mt-2 mb-4" Text="Add Product" OnClick="addProductBtn_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
