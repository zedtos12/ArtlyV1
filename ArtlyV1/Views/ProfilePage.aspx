<%@ Page Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="ArtlyV1.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link rel="stylesheet" href="CSS/ProfilePageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profileWrapper d-flex align-items-center justify-content-center flex-column pt-5 pb-5">
        <div class="profileTitle mb-3"><%=username%>'s Profile</div>
        <div class="profilePictureContainer d-flex justify-content-center align-items-center mb-4">
            <asp:Image ID="profilePicture" CssClass="profilePicture" runat="server" />
        </div>
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

            <div class="userTransactionHistoryWrapper mt-5 align-items-center justify-content-center d-flex flex-column">
                <div class="userTransactionHistoryTitle"> Your Transaction History </div>
                <div class="userTransactionHistoryContent d-flex flex-column mt-3 pb-4 pl-2">
                    <div class="userTransactionListTitle d-flex">
                        <div class="transactionDateTitle"> Date </div>
                        <div class="transactionStatusTitle"> Status </div>
                        <div class="transactionPaymentMethodTitle"> Payment Method </div>
                        <div class="transactionAddressNameTitle"> Address Name </div>
                        <div class="transactionDetailTitle"> Details </div>
                    </div>
                    <div class="userTransactionListWrapper d-flex flex-column">
                        <asp:Repeater ID="userTransactionRepeater" runat="server">
                            <ItemTemplate>
                                <div class="userTransactionWrapper d-flex align-items-center">
                                    <div class="userTransactionDate"><%#Eval("OrderDate", "{0:dd-MM-yyyy}")%></div>
                                    <div class="userTransactionStatus"><%#Eval("LtStatu.StatusName")%></div>
                                    <div class="userTransactionPaymentMethod"><%#Eval("LtPaymentMethod.PaymentMethodName")%></div>
                                    <div class="userTransactionAddressName"><%#(Eval("TrUserAddress.AddressName") == null) ? "No Shipping (Digital)" : Eval("TrUserAddress.AddressName")%></div>
                                    <div class="userTransactionDetail">
                                        <asp:HyperLink ID="userTransactionDetailHyperlink" runat="server" CssClass="userTransactionDetailHyperlink" NavigateUrl='<%#String.Format("~/Views/TransactionDetailPage.aspx?ID={0}", Eval("IdTransaction"))%>'> Detail </asp:HyperLink>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    
                </div>
                
            </div>
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
        <% } %>
    </div>
</asp:Content>
