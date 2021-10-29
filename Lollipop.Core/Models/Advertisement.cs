namespace Lollipop.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class Advertisement
    {
        /// <summary>
        /// Advertisement identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Author's id
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Visitor counter
        /// </summary>
        public int VisitorCounter { get; private set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Categories
        /// </summary>
        public IEnumerable<Category> Categories { get; private set; }

        /// <summary>
        /// Keywords
        /// </summary>
        public IEnumerable<Keyword> Keywords { get; private set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreationDate { get; private set; }

        private Advertisement(int userId, string title, string content, IEnumerable<Category> categories, IEnumerable<Keyword> keywords)
        {
            UserId = userId;
            VisitorCounter = 0;
            Title = title;
            Content = content;
            Categories = categories;
            Keywords = keywords;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Create new advertisement
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="title">Advertisement title</param>
        /// <param name="content">Content</param>
        /// <param name="categories">Categories</param>
        /// <param name="keywords">Keywords</param>
        /// <returns>New advertisement</returns>
        public static Advertisement Create(int userId, string title, string content, IEnumerable<Category> categories, IEnumerable<Keyword> keywords)
        {
            return new(userId, title, content, categories, keywords);
        }
    }
}
