using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class MessagePage : System.Web.UI.Page
    {
        MessageHandler messageHandler = new MessageHandler();
        List<Message> messages = new List<Message>();

        String userID, receiverID;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Session["user"].ToString();
            userID = "24f5f8f0-dc1c-4785-a4ed-8947a3efa32a";
            userID = "1f6a9ad8-520a-4e75-9e71-e086697d563c";
            string receiveruUsername = Request.QueryString["recieverUsername"];
            receiveruUsername = "bonif";
            receiveruUsername = "admin";
            receiverID = messageHandler.GetUserID(receiveruUsername);
            string receiverFullName = messageHandler.GetFullName(receiverID);
            fullnameLabel.InnerText = receiverFullName;
  
            usernameLabel.InnerText = receiveruUsername;
            if (receiverID == null)
            {
                Response.Redirect("HomePage.aspx");
            }

            messages = messageHandler.GetMessagesByUserId(userID, receiverID);
            foreach (Message message in messages)
            {
                message.Content = message.Content.Replace("\n", "<br />");
            }

            if (!IsPostBack)
            {
                rptMessages.DataSource = messages;
                rptMessages.DataBind();
            }
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("sendBtn_Click");
            String message = messageBox.Value;
            messageHandler.SendMessage(userID, receiverID, message, DateTime.Now);
            Response.Redirect("MessagePage.aspx?recieverID=" + receiverID);
        }

        protected void rptMessages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Message message = (Message)e.Item.DataItem;
                HtmlGenericControl messageContainer = e.Item.FindControl("messageContainer") as HtmlGenericControl;
                string currentClasses = messageContainer.Attributes["class"] ?? string.Empty;
                if (IsUserMessage(message))
                {
                    messageContainer.Attributes["class"] = currentClasses + " user-message";
                }
                else
                {
                    messageContainer.Attributes["class"] = currentClasses + " other-message";
                }
            }
        }

        public bool IsUserMessage(Message message)
        {           
            return message.IdSender == userID;
        }

        public string GetMessageContent(object dataItem)
        {
            Message message = (Message)dataItem;
            return message.Content;
        }

        public string GetMessageTimestamp(object dataItem)
        {
            Message message = (Message)dataItem;
            return message.timestamp.ToString("g");
        }
    }
}