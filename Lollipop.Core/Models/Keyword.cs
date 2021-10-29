namespace Lollipop.Core.Models
{
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

        private Keyword(string name)
        {
            Name = name.ToLower();
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
