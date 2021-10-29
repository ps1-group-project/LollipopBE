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
        public IEnumerable<Attribute> Attributes { get; private set; }

        private Category(string name, IEnumerable<Attribute> attributes)
        {
            Name = name;
            Attributes = attributes;
        }

        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="name">Name of category</param>
        /// <param name="attributes">List of attributes</param>
        /// <returns>New category</returns>
        public static Category Create(string name, IEnumerable<Attribute> attributes)
        {
            return new(name, attributes);
        }
    }
}
