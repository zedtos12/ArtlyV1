<%@ Page Title="Artly | Your Cart" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ShoppingCartPage.aspx.cs" Inherits="ArtlyV1.Views.ShoppingCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/ShoppingCartPageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cartWrapper d-flex align-content-center mt-5 mr-5 flex-column mb-5">
        <div class="cartTitle"> Your Cart</div>
        <div class="cartSubtitle mb-3"> You have <span class="cartSubtitleHighlight"><%=itemQty%> item(s)</span> in your cart.</div>
        <div class="cartContent d-flex align-items-center justify-content-around">
            <div class="cartItemListWrapper d-flex flex-column mt-3 pb-4 pl-2">
                <div class="cartItemListTitle d-flex">
                    <div class="productTitle"> Product </div>
                    <div class="priceTitle"> Price </div>
                    <div class="quantityTitle"> Quantity </div>
                    <div class="totalPriceTitle"> Total Price </div>
                </div>
                <asp:Repeater ID="cartItemRepeater" runat="server" OnItemDataBound="cartItemRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="cartItemWrapper d-flex align-items-center mt-2">
                            <img class="cartItemImage" src="<%#Eval("product.ProductImage")%>" />
                            <div class="cartItemDescription">
                                <div class="cartItemName"><%#Eval("product.ProductName")%></div>
                                <div class="cartItemSellerName"><%#Eval("sellerName")%></div>
                                <asp:Button ID="removeBtn" runat="server" Text="Remove" class="removeBtn btn" CommandArgument='<%#Eval("product.IdProduct")%>' OnClick="removeBtn_Click" />
                            </div>
                            <div class="cartItemPrice">IDR <%#String.Format("{0:N2}", Eval("product.Price"))%></div>
                            <div class="cartItemQuantity d-flex justify-content-center align-items-center">
                                <asp:Button ID="decrementQtyBtn" runat="server" Text="-" class="qtyBtn btn" CommandArgument='<%#Eval("product.IdProduct")%>' OnClick="decrementQtyBtn_Click" UseSubmitBehavior="false"/>
                                <%#Eval("qty")%>
                                <asp:Button ID="incrementQtyBtn" runat="server" Text="+" class="qtyBtn btn" CommandArgument='<%#Eval("product.IdProduct")%>' OnClick="incrementQtyBtn_Click" UseSubmitBehavior="false"/>
                            </div>
                            <div class="cartItemTotalPrice">IDR <%#String.Format("{0:N2}", (int.Parse(Eval("qty").ToString()) * decimal.Parse(Eval("product.Price").ToString())))%></div>
                        </div>
                        <div class="cartItemSeparator mt-2"></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="summaryWrapper p-4">
                <div class="summaryTitle mb-4"> Cart Summary </div>
                <div class="summaryContent">
                    <div class="summarySubtotal d-flex justify-content-between"> Subtotal <span class="summaryPriceHighlight">IDR <%=subtotalPrice.ToString("#,##0.00")%></span></div>
                    <div class="summaryTax d-flex justify-content-between"> Sales Tax (10%) <span class="summaryPriceHighlight">IDR <%=tax.ToString("#,##0.00")%></span></div>
                    <div class="summarySeparator mt-2 mb-2"></div>
                    <div class="summaryCurrentBalance d-flex justify-content-between"> Current Balance <span class="summaryPriceHighlight">IDR <%=currentBalance.ToString("#,##0.00")%></span></div>
                    <div class="summaryTotal d-flex justify-content-between"> Total Price <span class="summaryPriceHighlight">IDR <%=totalPrice.ToString("#,##0.00")%></span></div>
                    
                    <% if (itemQty <= 0)
                    { %>
                        <div class="noItems non-functional-btn btn mt-5"> No items in cart </div>
                    <% } else if (currentBalance >= totalPrice)
                    { %>
                        <asp:Button ID="paymentBtn" runat="server" class="btn btn-outline-light mt-5" Width="100%" Text="Checkout" OnClick="paymentBtn_Click" />
                    <% } else 
                    { %>
                        <div class="notEnoughBalance non-functional-btn btn mt-5"> Not enough balance </div>
                    <% } %>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
