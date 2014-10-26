/*Create a [Version] attribute that can be applied to
 * structures, classes, interfaces, enumerations and methods
 * and holds a version in the format major.minor (e.g. 2.11).
 * Apply the version attribute to a sample class and display 
 * its version at runtime.
*/

namespace Point
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
        AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Method,
        AllowMultiple = false)]
    class VersionAttribute : Attribute
    {
        public VersionAttribute(double value)
        {
            this.Value = value;
        }

        public double Value { get; private set; }
    }
}
