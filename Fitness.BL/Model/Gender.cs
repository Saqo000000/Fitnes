using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// name of gender
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name">Name of gender</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cant be empty or null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
