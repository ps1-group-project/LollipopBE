namespace Lollipop.Core.Models
{
    using System.Collections.Generic;

    public class Category
    {
        /// <summary>
        /// Category identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// List of attributes for category.
        /// </summary>
        public IEnumerable<AttributeC> Attributes { get; private set; } = new List<AttributeC>();

        /// <summary>
        /// List of advertisements
        /// </summary>
        public IEnumerable<Advertisement> Advertisements { get; private set;} = new List<Advertisement>();

        private Category(){}

        private Category(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="name">Name of category</param>
        /// <param name="attributes">List of attributes</param>
        /// <returns>New category</returns>
        public static Category Create(string name)
        {
            return new(name);
        }
    }
}
