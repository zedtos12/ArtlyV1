<%@ Page Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="ArtlyV1.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link rel="stylesheet" href="CSS/ProfilePageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profileWrapper d-flex align-items-center justify-content-center flex-column pt-5 pb-5">
        <div class="profileTitle mb-3"><%=username%>'s Profile</div>
        <img class="profilePicture mb-2" src="<%=profilePicPath%>"/>
        <div class="profileUsername mb-2"><%=username%></div>
        <div class="profileUserDescription mb-2"><%=userDescription%></div>

        <%if (userDOB != null)
        { %>
            <div class="profileUserDOB mb-3">Date Of Birth: <%=userDOB%></div>
        <% }%>

        <%if (phoneNumber != null)
        { %>
            <div class="profilePhoneNumber">
                <img class="phoneIcon" src="Images/Profile/PhoneIcon.png"/>
            </div>
        <% } %>

        <%if (isOwnerAccessing())
        { %>
            <asp:Button ID="updateBtn" CssClass="btn btn-outline-light mt-2" runat="server" Text="Update Profile" OnClick="updateBtn_Click"/>
        <% } %>

        <%if (isShownUserSeller())
        { %>
            <div class="profileProductListTitle mt-5 mb-3"><%=username%>'s Art</div>

            <section class="section-products" style="padding:0; width: 70%;">
		        <div class="container" style="padding-top: 20px; ">
			        <div class="row justify-content-center">
                        <asp:Repeater ID="profileProductRepeater" runat="server">
                            <ItemTemplate>
                                    <div class="col-md-6 col-lg-4 col-xl-3">
                                        <asp:HyperLink runat="server" ID="productDetailLink" NavigateUrl='<%#Eval("IdProduct", "~/Views/ProductDetail.aspx?ID={0}")%>'>
                                                <div class="single-product" style="background: url('<%#Eval("ProductImage")%>') no-repeat center center; background-size: cover; max-height:290px;">
                                                <div class="part-1">
                                                    <ul>
                                                        <label class="labelProductName"><%#Eval("ProductName") %></label>
                                                        <label class="labelSellerName"><%#Eval("MsUser.UserName") %></label>
                                                        <label class="labelPrice">Rp <%#String.Format("{0:N2}", Eval("Price"))%></label>
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
        <% } %>
    </div>
</asp:Content>
