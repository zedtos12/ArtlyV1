<%@ Page Title="Artly | Message" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="MessagePage.aspx.cs" Inherits="ArtlyV1.Views.MessagePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/MessagePageStyle.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.5/jquery.mCustomScrollbar.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="chat-container">
        <div class="chat">
            <div class="chat-title">
                <h1 id="fullnameLabel" runat="server">Fabio Ottaviani</h1>
                <h2 id="usernameLabel" runat="server">Supah</h2>
                 
                <figure class="avatar">
                    <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/156381/profile/profile-80.jpg" />
                </figure>
            </div>

            <div class="messages" id="messagesContainer">

                <asp:Repeater ID="rptMessages" runat="server" OnItemDataBound="rptMessages_ItemDataBound">
                    <ItemTemplate>
                        <div class='message <%= IsUserMessage(Container.DataItem) ? "user-message" : "other-message" %>' id="messageContainer" runat="server">
                            <div class="message-content">
                                <%# GetMessageContent(Container.DataItem) %>
                            </div>
                            <div class="message-timestamp">
                                <%# GetMessageTimestamp(Container.DataItem) %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="message-box">
                <textarea runat="server" id="messageBox" type="text" class="message-input" placeholder="Type message..."></textarea>
                <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="sendBtn_Click" />
            </div>
        </div>
    </div>
    <div class="bg"></div>
</asp:Content>
