<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ArtlyV1.Views.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/ProductDetailPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="detailWrapper py-5 d-flex justify-content-center align-items-center">
            <div class="container px-4 px-lg-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6"><img class="card-img-top mb-5 mb-md-0" src="<%=productImage %>"" alt="..." /></div>
                    <div class="col-md-6">
                        <div class="small mb-1">Seller: <%=sellerName %></div>
                        <h1 class="display-5 fw-bolder"><%=productName %></h1>
                        <div class="fs-5 mb-2">IDR <%=productPrice.ToString("#,##0.00") %></div>
                        <p class="lead"><%=productDescription %></p>
                        <div class="d-flex">
                            <input class="form-control text-center me-3 mr-3" id="inputQuantity" type="number" value="1" min="1" max="99" onkeypress="if(this.value.length == 2) return false;" onkeydown="return event.key != 'Enter';" style="max-width: 3rem" />
                            <button class="btn btn-outline-light" type="button">
                                Add to cart
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
