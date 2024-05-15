using System;
using System.Linq;

namespace RdpConnection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RdpAllowedValuesAttribute : Attribute
    {
        public RdpAllowedValuesAttribute(params object[] allowedValues)
            => _allowedValues = allowedValues ?? new object[] { };

        private readonly object[] _allowedValues;

        public object[] Values => _allowedValues;

        public bool IsValid(object o)
            => Values.Contains(o);
    }
}
