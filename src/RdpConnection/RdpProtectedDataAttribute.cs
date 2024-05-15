using System;

namespace RdpConnection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RdpProtectedDataAttribute : Attribute
    {
        public RdpProtectedDataAttribute() { }
    }
}
