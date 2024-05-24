using System;
using System.Linq;

namespace RdpConnection
{
    /// <summary>
    /// This attribute is used to specify the allowed values for a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RdpAllowedValuesAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RdpAllowedValuesAttribute"/> class.
        /// </summary>
        /// <param name="allowedValues">Allowed values</param>
        public RdpAllowedValuesAttribute(params object[] allowedValues)
            => _allowedValues = allowedValues ?? new object[] { };

        private readonly object[] _allowedValues;

        /// <summary>
        /// Allowed values
        /// </summary>
        public object[] Values => _allowedValues;

        /// <summary>
        /// Check if the object is valid.
        /// </summary>
        /// <param name="o">Value for testing</param>
        /// <returns>
        /// If the object is valid, return true; otherwise, return false.
        /// </returns>
        public bool IsValid(object o)
            => Values.Contains(o);
    }
}
