<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderHistoryPage.aspx.cs" Inherits="ArtlyV1.Views.OrderHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="OrderHistoryGV" runat="server" AutoGenerateColumns="False" OnRowCommand="OrderHistoryGV_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdTransaction" HeaderText="ID" SortExpression="IdProduct" />
        <asp:BoundField DataField="OrderDate" HeaderText="Name" SortExpression="OrderDate" />
        <asp:BoundField DataField="LtStatus.StatusName" HeaderText="Status" SortExpression="LtStatus.StatusName" />
        <asp:BoundField DataField="LtPaymentMethod.PaymentMethodName" HeaderText="Payment Method" SortExpression="LtPaymentMethod.PaymentMethodName" />
        <asp:BoundField DataField="TrackingId" HeaderText="TrackingID" SortExpression="TrackingId" />
        <asp:ButtonField ButtonType="Button" CommandName="CompleteProduct" HeaderText="Action" ShowHeader="True" Text="Detail"/>
    </Columns>
</asp:GridView>
</asp:Content>
