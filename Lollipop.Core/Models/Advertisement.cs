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
        public string Title { get;private set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get;private set; }

        /// <summary>
        /// Categories
        /// </summary>
        /// 
        public Category Category { get; private set; }


        /// <summary>
        /// Keywords
        /// </summary>
        public ICollection<Keyword> Keywords { get; private set; } = new List<Keyword>();

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreationDate { get; private set; }
        public void SetTitle(string title) => this.Title = title;
        public void SetContent(string content) => this.Content = content;
        public void SetCategory(Category category) => this.Category = category;
        private Advertisement(){}

        private Advertisement(int userId, string title, string content, Category category)
        {
            UserId = userId;
            VisitorCounter = 0;
            Title = title;
            Content = content;
            Category = category;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Create new advertisement
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="title">Advertisement title</param>
        /// <param name="content">Content</param>
        /// <param name="category">Category</param>
        /// <param name="keywords">Keywords</param>
        /// <returns>New advertisement</returns>
        public static Advertisement Create(int userId, string title, string content, Category category)
        {
            return new(userId, title, content, category);
        }

        public void AddKeyword(Keyword keyword)
        {
            if (!Keywords.Contains(keyword))
            {
                Keywords.Add(keyword);
            }
        }

        public void RemoveKeyword(Keyword keyword)
        {
            Keywords.Remove(keyword);
        }
    }
}
