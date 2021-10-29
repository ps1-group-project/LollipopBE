namespace Lollipop.Core.Models
{
    using System.Collections.Generic;
    public class Keyword
    {
        /// <summary>
        /// Keyword identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Keyword name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// List of advertisements
        /// </summary>
        public IEnumerable<Advertisement> Advertisements{get;private set;}

        private Keyword(){}

        private Keyword(string name)
        {
            Name = name.ToLower();
            Advertisements = new List<Advertisement>();
        }

        /// <summary>
        /// Create new keyword
        /// </summary>
        /// <param name="name">Keyword name</param>
        /// <returns>New keyword</returns>
        public static Keyword Create(string name)
        {
            return new(name);
        }
    }
}
