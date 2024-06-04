<%@ Page Title="Artly | Transaction Details" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ArtlyV1.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/TransactionDetailPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="transactionDetailContainer d-flex flex-column pt-5 pb-5 align-items-center">
        <div class="transactionDetailTitle pl-5"> Transaction Details </div>
        <div class="transactionDetailSubtitle pl-5"> You purchased <span class="transactionDetailSubtitleHighlight"><%=itemQty%> </span> item(s) in this transaction.</div>
        <div class="transactionDetailContent d-flex flex-column mt-3 pb-4 pl-2 align-items-center">
            <div class="transactionDetailListWrapper d-flex flex-column mt-3 pb-4 pl-2">
                <div class="transactionDetailListTitle d-flex">
                    <div class="productTitle"> Product </div>
                    <div class="priceTitle"> Price </div>
                    <div class="quantityTitle"> Quantity </div>
                    <div class="totalPriceTitle"> Total Price </div>
                </div>
                <asp:Repeater ID="transactionDetailRepeater" runat="server">
                    <ItemTemplate>
                        <div class="transactionDetailWrapper d-flex align-items-center mt-2">
                            <img class="transactionDetailImage" src="<%#Eval("MsProduct.ProductImage")%>" />
                            <div class="transactionDetailDescription">
                                <div class="transactionDetailName"><%#Eval("MsProduct.ProductName")%></div>
                                <div class="transactionDetailSellerName"><%#Eval("MsProduct.MsUser.UserName")%></div>
                            </div>
                            <div class="transactionDetailPrice">IDR <%#String.Format("{0:N2}", Eval("MsProduct.Price"))%></div>
                            <div class="transactionDetailQuantity"><%#Eval("Quantity")%></div>
                            <div class="transactionDetailTotalPrice">IDR <%#String.Format("{0:N2}", (int.Parse(Eval("Quantity").ToString()) * decimal.Parse(Eval("MsProduct.Price").ToString())))%></div>
                        </div>
                        <div class="transactionDetailSeparator mt-2"></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="transactionTotalSummary mt-4 d-flex flex-column p-4">
                <div class="transactionSubtotal d-flex justify-content-between"> Transaction Subtotal <span class="transactionPriceHighlight">IDR <%=subtotalTransactionPrice.ToString("#,##0.00")%></span> </div>
                <div class="transactionTax d-flex justify-content-between"> Transaction Tax (10%) <span class="transactionPriceHighlight">IDR <%=tax.ToString("#,##0.00")%></span> </div>
                <div class="transactionDetailSeparator mt-3"></div>
                <div class="transactionTotal d-flex justify-content-between mt-3"> Transaction Total <span class="transactionPriceHighlight">IDR <%=totalTransactionPrice.ToString("#,##0.00")%></span> </div>
            </div>
        </div>
    </div>
</asp:Content>
