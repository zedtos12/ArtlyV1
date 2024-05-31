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
            return messages;
        }
    }
}