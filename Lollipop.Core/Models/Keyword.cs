namespace Lollipop.Core.Models
{
    using System.Collections.Generic;
    public class Keyword : Base
    {


        /// <summary>
        /// Keyword name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of advertisements
        /// </summary>
        public ICollection<Advertisement> Advertisements { get; private set;} = new List<Advertisement>();

        private Keyword(){}

        private Keyword(string name)
        {
            Name = name;
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
