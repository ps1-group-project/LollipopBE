namespace Lollipop.Core.Models
{
    using System;

    public class Message : Base
    {

        /// <summary>
        /// Author's Identifier.
        /// </summary>
        public string AuthorId { get; private set; }

        /// <summary>
        /// Target message identifier.
        /// </summary>

        public string TargetId { get; private set; }

        /// <summary>
        /// Content.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreationDate { get; init; }

        private Message(){}

        private Message(string userId, string targetId, string content)
        {
            AuthorId = userId;
            TargetId = targetId;
            Content = content;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Create new Message
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="targetId">Target identifier</param>
        /// <param name="content">Content of message</param>
        /// <returns>New Message</returns>
        public static Message Create(string userId, string targetId, string content)
        {
            return new(userId, targetId, content);
        }

    }
}
