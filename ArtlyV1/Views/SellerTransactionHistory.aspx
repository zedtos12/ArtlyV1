<%@ Page Title="" Language="C#" MasterPageFile="~/Views/SellerDashboard.Master" AutoEventWireup="true" CodeBehind="SellerTransactionHistory.aspx.cs" Inherits="ArtlyV1.Views.SellerTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/Seller-trans.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Container-fluid ml-5 mt-5 mr-5">
        <div class="row m-0">
            <p class="text-left text-white font-weight-bold" style="font-size:1.5rem">Transaction History</p>
        </div>
        <div class="p-2 d-flex align-items-center justify-content-start con-header">
            <asp:Button ID="DititalBTN" runat="server" CssClass="p-3 w-20 underline-box" Text="Digital" OnClick="DititalBTN_Click" />
            <asp:Button ID="NonDigitalBTN" runat="server" CssClass="p-3 w-20 underline-box" Text="Non-Digital" OnClick="NonDigitalBTN_Click"  />
        </div>
        <div class="container-fluid mt-3">
            <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle btn-filter-transaction" type="button" id="dropdownMenuButton" data-toggle="dropdown">
                    <i class="fa fa-filter"></i>
                    Filter
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <asp:HyperLink ID="HlOnProcess" runat="server" CssClass="dropdown-item" Text="On-Process"> </asp:HyperLink>
                     <asp:HyperLink ID="HlOnDelivery" runat="server" CssClass="dropdown-item" Text="On-Delivery"> </asp:HyperLink>
                    <asp:HyperLink ID="HlComplete" runat="server" CssClass="dropdown-item" Text="Complete"> </asp:HyperLink>
                 </div>
            </div>
        </div>
        <p class="text-white-30 mt-3 mr-2" style="color:#FCBF49;"><%= (filter == "" || filter == null ? "All Transaction" : filter )%></p>
        <div class="table-responsive mt-1">
            <table class="table table-hover">
                <thead>
                    <tr class="text-white">
                        <th>User</th>
                        <th>Product</th>
                        <th>Sale</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="TransactionHistoryRPT">
                        <ItemTemplate>
                            <tr>
                                <td class="text" style="color:#bbb"><%# Eval("Buyer") %></td>
                                <td class="text" style="color:#bbb"><%# Eval("ProductName") %></td>
                                <td class="text" style="color:#bbb"> Rp <%# String.Format("{0:N2}", Eval("Price"))%><i class="fa fa-arrow-up"></i></td>
                                <td><label class="badge badge-success">Completed</label></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
     <script src="JS/popper.min.js"></script>
</asp:Content>
