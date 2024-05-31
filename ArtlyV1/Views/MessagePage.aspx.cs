using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class MessagePage : System.Web.UI.Page
    {
        MessageHandler messageHandler = new MessageHandler();
        List<Message> messages = new List<Message>();

        String userID, recieverID;
        protected void Page_Load(object sender, EventArgs e)
        {
            // userID = Session["user"].ToString();
            recieverID = Request.QueryString["recieverID"];
            if (recieverID == null)
            {
                Response.Redirect("HomePage.aspx");
            }

            messages = messageHandler.GetMessagesByUserId(userID, recieverID);
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            // String message = messageTB.Text;
            // messageHandler.SendMessage(userID, recieverID, message, DateTime.Now);
            Response.Redirect("MessagePage.aspx?recieverID=" + recieverID);
        }
    }
}