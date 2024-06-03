<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="ArtlyV1.Views.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/PaymentPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="paymentWrapper d-flex align-items-center justify-content-center">
        <div class="paymentContainer d-flex flex-column p-5 mt-3 mb-3">
            <div class="paymentTitle"> Checkout </div>
            <div class="paymentSubtitle"> Select payment method below: </div>
            <div class="paymentMethodListWrapper d-flex flex-wrap justify-content-around mb-2">
                <div class="paymentMethodWrapper d-flex justify-content-center align-items-center">
                    <asp:RadioButton ID="balanceRadioBtn" GroupName="paymentMethod" runat="server" class="paymentMethodRadioBtn" AutoPostBack="true" Checked="true" />
                    <span class="paymentMethodName ml-2"> Balance </span>
                </div>
                <div class="paymentMethodWrapper d-flex justify-content-center align-items-center">
                    <asp:RadioButton ID="BCARadioBtn" GroupName="paymentMethod" runat="server" class="paymentMethodRadioBtn" AutoPostBack="true" />
                    <img class="paymentMethodImage ml-2" src="Images/Payment/BCALogo.png" />
                    <span class="paymentMethodName ml-2"> BCA </span>
                </div>
                <div class="paymentMethodWrapper d-flex justify-content-center align-items-center">
                    <asp:RadioButton ID="GoPayRadioBtn" GroupName="paymentMethod" runat="server" class="paymentMethodRadioBtn" AutoPostBack="true" />
                    <img class="paymentMethodImage ml-2" src="Images/Payment/GoPayLogo.png"/>                    
                    <span class="paymentMethodName ml-2"> GoPay </span>
                </div>
            </div>
            <div class="paymentMethodContent d-flex flex-column">
                <%if(!isAllItemDigital())
                { %>
                    <div class="paymentTitle"> Shipping Address </div>
                    <div class="shippingContent d-flex flex-column align-items-center pt-3 pb-3 mt-3 mb-3">
                        <asp:RadioButtonList ID="userAddressRBList" runat="server" CssClass="userAddressRBList"></asp:RadioButtonList>
                    </div>
                <% } %>

                <div class="paymentTitle"> Billing Details </div>

                <% if (balanceRadioBtn.Checked == true)
                { %>
                        <div class="paymentContent mb-3">
                            <div class="paymentTotal d-flex justify-content-between"> Total <span class="paymentHighlight">IDR <%=total.ToString("#,##0.00")%></span></div>
                            <div class="paymentCurrentBalance d-flex justify-content-between"> Current Balance <span class="paymentHighlight">IDR <%=currentBalance.ToString("#,##0.00")%></span></div>
                            <div class="paymentSeparator mt-2 mb-2"></div>
                            <div class="paymentResultingBalance d-flex justify-content-between"> Resulting Balance <span class="paymentHighlight">IDR <%=resultingBalance.ToString("#,##0.00")%></span></div>
                        </div>
                <% } else if(BCARadioBtn.Checked == true)
                { %>
                        <div class="paymentContent mb-3">
                            <div class="paymentTotal d-flex justify-content-between"> Total <span class="paymentHighlight">IDR <%=total.ToString("#,##0.00")%></span></div>
                        </div>
                <% } else if(GoPayRadioBtn.Checked == true)
                { %>
                        <div class="paymentContent mb-3">
                            <div class="paymentTotal d-flex justify-content-between"> Total <span class="paymentHighlight">IDR <%=total.ToString("#,##0.00")%></span></div>
                        </div>
                <% } %>

                <div id="alertBox" class="alert alert-danger" role="alert" runat="server" visible="false">
                     <asp:Label ID="errorLabel" runat="server"></asp:Label>
                </div>

                <div id="successBox" class="alert alert-success mt-3" role="alert" runat="server" visible="false">
                    <asp:Label ID="successLabel" runat="server"></asp:Label>
                </div>

                <asp:Button ID="paymentBtn" runat="server" Text="Proceed with Payment" class="btn btn-outline-light mt-2" OnClick="paymentBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>
