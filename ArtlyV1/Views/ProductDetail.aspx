<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ArtlyV1.Views.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/ProductDetailPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="detailWrapper py-5 d-flex justify-content-center align-items-center">
            <div class="container px-4 px-lg-5" style="width: 100%; max-width: 100%">
                <div class="row gx-4 gx-lg-5 align-items-center justify-content-center d-flex">
                    <div class="col-md-6 align-items-center justify-content-center d-flex mr-5" style="max-width: fit-content;"><img class="productImage card-img-top mb-5 mb-md-0" src="<%=productImage %>"" alt="..." /></div>
                    <div class="productText col-md-6 d-flex flex-column" style="max-width: fit-content;">
                        <h1 class="display-5 fw-bolder"><%=productName %></h1>
                        <div class="small mb-1">Seller: <asp:HyperLink runat="server" class="sellerLink" NavigateUrl="~/Views/ProfilePage.aspx"><%=sellerName %></asp:HyperLink></div>
                        <div class="fs-5 mb-2">IDR <%=productPrice.ToString("#,##0.00") %></div>
                        <p class="lead"><%=productDescription %></p>
                        <div id="errorBox" class="alert alert-danger" role="alert" runat="server" visible="false">
                            <asp:Label ID="errorLabel" runat="server"></asp:Label>
                        </div>
                        <div id="successBox" class="alert alert-success" role="alert" runat="server" visible="false">
                            <asp:Label ID="successLabel" runat="server"></asp:Label>
                        </div>
                        <div class="d-flex">
                            <input class="form-control text-center me-3 mr-3" id="inputQuantity" runat="server" type="number" value="1" min="1" max="99" onkeypress="if(this.value.length == 2) return false;" onkeydown="return event.key != 'Enter';" style="max-width: 3rem" />
                            <asp:button ID="addCartButton" runat="server" class="btn btn-outline-light" Text="Add to cart" OnClick="addCartButton_Click"></asp:button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
