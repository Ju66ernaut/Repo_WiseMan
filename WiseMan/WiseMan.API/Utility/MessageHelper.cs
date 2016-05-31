﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WiseMan.API.Models;

namespace WiseMan.API.Utility
{
    /// <summary>
    /// To serve as the DAL for message related actions
    /// </summary>
    public static class MessageHelper
    {
        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="body"></param>
        /// <param name="authorId"></param>
        /// <param name="tags"></param>
        public static void CreateMessage(string messageBody, Guid authorId, List<string> tags)
        {
            string tagString = "";
            foreach (var item in tags)
            {
                tagString += item + ",";
            }
            using(Data.WiseManEntities db = new Data.WiseManEntities())
            {
                db.CreateMessage(messageBody, tagString, authorId);
            }
        }

        /// <summary>
        /// Gets a message by id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        internal static Message GetMessageById(Guid messageId)
        {
            Message message;
            using(Data.WiseManEntities db = new Data.WiseManEntities())
            {
                message = new Message(db.GetMessageById(messageId).FirstOrDefault());
            }
            return message;
        }
    }
}