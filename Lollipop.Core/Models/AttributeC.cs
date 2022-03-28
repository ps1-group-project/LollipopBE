using System.Collections;
using System.Collections.Generic;

namespace Lollipop.Core.Models
{
    public class AttributeC
    {
        /// <summary>
        /// Attribute identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Attribute type.
        /// </summary>

        public List<string> Values { get; private set; }

        private AttributeC(string name, List<string> values)
        {
            Name = name;
            Values= values;
        }

        /// <summary>
        /// Creates new attribute
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Attribute values</param>
        /// <returns></returns>
        public static AttributeC Create(string name, List<string> values)
        {
            return new(name, values);
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddValue(string value)
        {
            if (!Values.Contains(value))
            {
                Values.Add(value);
            }
        }

        public void RemoveValue(string value)
        {
            Values.Remove(value);
        }
    }
}
