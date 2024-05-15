using System;
using System.Text.RegularExpressions;

namespace RdpConnection
{
    internal static class Constants
    {
        internal static readonly char[] CommaSeparator = new char[] { ',', };

        internal static readonly char[] SemicolonSeparator = new char[] { ';', };

        internal static readonly Lazy<Regex> RdpLineRegexFactory = new Lazy<Regex>(
            () => new Regex("(?<PropertyName>[^:]+):(?<TypeSign>[^:]+):(?<Rest>[^\r\n]*)"),
            false);
    }
}
