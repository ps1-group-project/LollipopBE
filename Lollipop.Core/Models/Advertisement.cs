﻿namespace Lollipop.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Advertisement : Base
    {
        /// <summary>
        /// Author's id
        /// </summary>
        public string UserId { get; private set; }

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
        public ICollection<Category> Categories { get; private set; } = new List<Category>();

        public ICollection<AttributeC> Attributes { get; private set; } = new List<AttributeC>();

        /// <summary>
        /// Keywords
        /// </summary>
        public ICollection<Keyword> Keywords { get; private set; } = new List<Keyword>();

        /// <summary>
        /// Collection if images
        /// </summary>
        public ICollection<AdvImage> Images { get; private set; } = new List<AdvImage>();

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreationDate { get; private set; }
        public void SetTitle(string title) => this.Title = title;
        public void SetContent(string content) => this.Content = content;
        private Advertisement(){}

        private Advertisement(string userId, string title, string content)
        {
            UserId = userId;
            VisitorCounter = 0;
            Title = title;
            Content = content;
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
        public static Advertisement Create(string userId, string title, string content)
        {
            return new(userId, title, content);
        }

        public void AddCategory(Category cat)
        {
            if (!Categories.Contains(cat))
            {
                Categories.Add(cat);
            }
        }

        public void RemoveCategory(Category cat)
        {
            Categories.Remove(cat);
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

        public void RemoveImage(AdvImage im)
        {
            Images.Remove(im);
        }

        public void AddImage(AdvImage im)
        {
            if (!Images.Contains(im))
            {
                Images.Add(im);
            }
        }

        public void AddAttribute(AttributeC att)
        {
            if (!Attributes.Contains(att))
            {
                Attributes.Add(att);
            }
        }

        public void RemoveAttribute(AttributeC att)
        {
            Attributes.Remove(att);
        }

        public bool SameAttributeValue(AttributeC att)
        {
            foreach (AttributeC attribute in Attributes)
            {
                if (attribute.Type == att.Type && attribute.Name == att.Name)
                {
                    return true;
                }
            }

            return false;
        }
        public void EditAttribute(AttributeC att)
        {
            foreach (AttributeC attribute in Attributes)
            {
                if (attribute.Type == att.Type)
                {
                    attribute.SetName(att.Name);
                }
            }
        }
    }
}
