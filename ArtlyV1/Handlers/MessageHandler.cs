using ArtlyV1.Factories;
using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class MessageHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();
        public void SendMessage(String IdSender, String IdReceiver, String content, DateTime timeSent)
        {
            Message message = MessageFactory.Create(Guid.NewGuid().ToString(), IdSender, IdReceiver, content, timeSent);
            System.Diagnostics.Debug.WriteLine("MessageHandler.SendMessage: " + message.IdMessage);
            System.Diagnostics.Debug.WriteLine("MessageHandler.Id: " + message.IdSender + " " + message.IdReceiver);
            db.Messages.Add(message);
            db.SaveChanges();
        }

        public void DeleteMessage(string IdMessage)
        {
            Message message = (from x in db.Messages where x.IdMessage == IdMessage select x).FirstOrDefault();
            message.IsActive = false;
            db.SaveChanges();
        }

        public List<Message> GetMessagesByUserId(string IdUser, string IdRecipient)
        {
            List<Message> messages = (from x in db.Messages 
                                      where (x.IdSender == IdUser && x.IdReceiver == IdRecipient) 
                                      || (x.IdSender == IdRecipient && x.IdReceiver == IdUser) 
                                      select x).ToList();
            messages.Sort((x, y) => DateTime.Compare(x.timestamp, y.timestamp));

            return messages;
        }

        public string GetUserID(string username)
        {
            string userID = (from x in db.MsUsers where x.UserName == username select x.IdUser).FirstOrDefault();
            return userID;
        }

        public string GetFullName(string IdUser)
        {
            string fullName = (from x in db.MsUsers where x.IdUser == IdUser select x.FullName).FirstOrDefault();
            return fullName;
        }
    }
}