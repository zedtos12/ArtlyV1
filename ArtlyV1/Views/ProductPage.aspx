<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="ArtlyV1.Views.ProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="CSS/ProductPageStyle.css" />
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper" style="min-height: 90vh; width: 100%;">
        <div class="container mt-5">

          <div class="row d-flex justify-content-center">

            <div class="col-md-8">

                <div class="card" style="margin: 0; padding: 0;">
              
                  <div class="input-box">
                        <asp:TextBox ID="searchBox" runat="server" CssClass="form-control" placeholder="Searching..." AutoPostBack="true" OnTextChanged="SearchBox_TextChanged" />
                    <i class="fa fa-search"></i>                    
                  </div>
                </div>
            </div>
          </div>
        </div>
      <div class="container mt-5 d-flex justify-content-around" style="width: 100%; max-width: 100%; padding-right: 20px; padding-left: 20px;">
          <div class="Filter">
              <div class="Type-Filter-Container">
                  <h1 style="color:white; font-size:25px">Types</h1>
			      <asp:Repeater runat="server" ID="TypeFilter">
                    <ItemTemplate>
                        <div class="form-check" style="margin-left: 10px" >
                            <input runat="server" class="form-check-input type-checkbox" type="checkbox" value='<%# Eval("IdProductType") %>' data-id='<%# Eval("IdProductType") %>' ID="typeCheckboxID" />
                            <label class="form-check-label" for="typeCheckboxID">
                                <%# Eval("ProductTypeName") %>
                            </label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="Categories-Filter-Container">
                <h1 style="color:white; font-size:25px; margin-top:20px">Categories</h1>
                <asp:Repeater runat="server" ID="CategoryFilter">
                    <ItemTemplate>
                        <div class="form-check" style="margin-left: 10px" >
						    <input runat="server" class="form-check-input type-checkbox" type="checkbox" value='<%# Eval("IdProductCategory") %>' data-id='<%# Eval("IdProductCategory") %>' ID="categoryCheckboxID" />
                            <label class="form-check-label" for="categoryCheckboxID">
                                <%# Eval("ProductCategoryName") %>
                            </label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
              </div>
              <asp:Button CssClass="btn btn-outline-warning" ID="ApplyFilter" runat="server" Text="Apply Filter" OnClick="ApplyFilter_Click" style="margin-left: 10px; margin-top: 10%"/>
          </div>
          <section class="section-products" style="padding:0; width: 70%;">
		    <div class="container" style="padding-top: 20px; ">
			    <div class="row">
                    <asp:Repeater runat="server" ID="ProductList">
                        <ItemTemplate>
                            <div class="col-md-6 col-lg-4 col-xl-3">
                                <asp:HyperLink runat="server" ID="productDetailLink" NavigateUrl='<%#Eval("IdProduct", "~/Views/ProductDetail.aspx?ID={0}")%>'>
                                    <div class="single-product" style="background: url('<%#Eval("ProductImage")%>') no-repeat center center; background-size: cover; max-height:290px;">
                                        <div class="part-1">
                                            <ul>
                                                <label class="labelProductName"><%#Eval("ProductName") %></label>
                                                <label class="labelSellerName"><%#Eval("MsUser.UserName") %></label>
                                                <label class="labelPrice">IDR <%#String.Format("{0:N2}", Eval("Price"))%></label>
                                            </ul>
                                        </div>
                                    </div>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>	    
			    </div>
		    </div>		
            </section>
      </div>
    </div>

    <script>
        $(document).ready(function () {
            $("#<%= searchBox.ClientID %>").on('keypress', function (e) {
            if (e.which == 13) {
                __doPostBack('<%= searchBox.UniqueID %>', '');
            }
        });
    });
    </script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>
