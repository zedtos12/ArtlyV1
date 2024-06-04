<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderDetailPage.aspx.cs" Inherits="ArtlyV1.Views.OrderDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="OrderDetailGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdProduct" HeaderText="ID" SortExpression="IdProduct" />
            <asp:BoundField DataField="MsProduct.ProductName" HeaderText="Name" SortExpression="MsProduct.ProductName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
    <asp:Label ID="TotalLabel" runat="server" Text=""></asp:Label>
</asp:Content>
