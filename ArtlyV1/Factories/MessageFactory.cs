using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ArtlyV1.Factories
{
    public class MessageFactory
    {
        public static Message Create(string IdMessage, string IdSender, string IdReceiver, string MessageContent, DateTime MessageDate)
        {
            Message message = new Message();
            message.IdMessage = IdMessage;
            message.IdSender = IdSender;
            message.IdReceiver = IdReceiver;
            message.Content = MessageContent;
            message.timestamp = MessageDate;
            message.IsActive = true;
            return message;
        }
    }
}