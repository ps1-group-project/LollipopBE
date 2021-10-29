namespace Lollipop.Core.Models
{
    using System;

    public class Message
    {
        /// <summary>
        /// Message identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Author's Identifier.
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Content.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreationDate { get; init; }

        private Message(){}

        private Message(int userId, string content)
        {
            UserId = userId;
            Content = content;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Create new Message
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="content">Content of message</param>
        /// <returns>New Message</returns>
        public static Message Create(int userId, string content)
        {
            return new(userId, content);
        }
    }
}
