namespace Lollipop.Core.Models
{
    public class AttributeC : Base
    {

        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Attribute type.
        /// </summary>
        public string Type { get; private set; }

        private AttributeC(string name, string type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Creates new attribute
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="type">Attri</param>
        /// <returns></returns>
        public static AttributeC Create(string name, string type)
        {
            return new(name, type);
        }

        public void SetName(string name)
        {
            Name = name;
        }
        public void SetType(string type)
        {
            Type = type;
        }
    }
}
