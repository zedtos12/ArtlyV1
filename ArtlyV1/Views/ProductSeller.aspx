<%@ Page Title="Artly | Your Products" Language="C#" MasterPageFile="~/Views/SellerDashboard.Master" AutoEventWireup="true" CodeBehind="ProductSeller.aspx.cs" Inherits="ArtlyV1.Views.ProductSeller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/ProductSeller.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Container-fluid ml-5 mt-5 mr-5">
    <div>
        <div class="row m-0">
            <p class="text-left text-white font-weight-bold" style="font-size:1.5rem">Products</p>
        </div>
    </div>
    <div class="mt-5 p-2 productSection">
        <div class="row">
            <asp:Repeater ID="ProductRPT" runat="server">
                <ItemTemplate>
                    <div class="container d-flex align-items-center p-2 m-2 card-product" style="width: 25rem;">
                        <img class="img-card" src="<%#Eval("ProductImage")%>" alt="Card image cap" />
                        <div class="card-body" ">
                            <h5 class="card-title text-white"><%# Eval("Description")%></h5>
                            <p class="card-text text-white" > Rp<%#String.Format("{0:N2}", Eval("Price"))%></p>
                            <asp:Button runat="server" CssClass="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("IdProduct") %>' OnCommand="Product_Command"/>
                            <asp:Button runat="server" CssClass="btn btn-warning" Text="Update" CommandName="Update" CommandArgument='<%# Eval("IdProduct") %>' OnCommand="Product_Command"/>
                        </div>
                    </div> 
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
</asp:Content>
