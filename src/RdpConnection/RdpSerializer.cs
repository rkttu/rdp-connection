using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace RdpConnection
{
    /// <summary>
    /// RDP serializer and deserializer.
    /// </summary>
    public static class RdpSerializer
    {
        /// <summary>
        /// Serializes the specified <see cref="RemoteDesktopPropertiesBase"/> instance as RDP properties.
        /// </summary>
        /// <typeparam name="TRdpProperties">
        /// The type of the RDP properties.
        /// </typeparam>
        /// <param name="rdpProperties">
        /// A RDP properties to serialize.
        /// </param>
        /// <param name="throwIfNotValid">
        /// Whether to throw an exception if the specified <paramref name="rdpProperties"/> is not valid.
        /// </param>
        /// <returns>
        /// List of serialized RDP properties.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws when the specified <paramref name="rdpProperties"/> is not valid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Throws when the property does not have the DataMemberAttribute.
        /// </exception>
        public static IEnumerable<string> Serialize<TRdpProperties>(
            this TRdpProperties rdpProperties, bool throwIfNotValid = true)
            where TRdpProperties : RemoteDesktopPropertiesBase
        {
            if (rdpProperties == default)
                yield break;

            var targetType = typeof(TRdpProperties);
            var targetTypeInfo = targetType.GetTypeInfo();

            if (targetTypeInfo.GetCustomAttribute<DataContractAttribute>() == default)
            {
                if (throwIfNotValid)
                    throw new ArgumentException($"Selected type '{typeof(TRdpProperties)}' does not have the DataContractAttribute.", nameof(rdpProperties));

                yield break;
            }

            var allProperties = targetType
                .GetRuntimeProperties()
                .ToArray();

            foreach (var eachProperty in allProperties)
            {
                var ignoreDataMemberAttribute = default(IgnoreDataMemberAttribute);
                var allowedValuesAttribute = default(RdpAllowedValuesAttribute);
                var defaultValueAttribute = default(DefaultValueAttribute);
                var rangeAttribute = default(RangeAttribute);
                var dataMemberAttribute = default(DataMemberAttribute);

                var propertyName = eachProperty.Name;
                var propertyType = eachProperty.PropertyType;

                foreach (var eachCustomAttribute in eachProperty.GetCustomAttributes(true))
                {
                    if (eachCustomAttribute is IgnoreDataMemberAttribute)
                        ignoreDataMemberAttribute = eachCustomAttribute as IgnoreDataMemberAttribute;
                    if (eachCustomAttribute is RdpAllowedValuesAttribute)
                        allowedValuesAttribute = eachCustomAttribute as RdpAllowedValuesAttribute;
                    if (eachCustomAttribute is DefaultValueAttribute)
                        defaultValueAttribute = eachCustomAttribute as DefaultValueAttribute;
                    if (eachCustomAttribute is RangeAttribute)
                        rangeAttribute = eachCustomAttribute as RangeAttribute;
                    if (eachCustomAttribute is DataMemberAttribute)
                        dataMemberAttribute = eachCustomAttribute as DataMemberAttribute;
                }

                if (ignoreDataMemberAttribute != null)
                    continue;

                if (dataMemberAttribute == null)
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' does not have DataMemberAttribute.");

                    continue;
                }

                var propertyValue = eachProperty.GetValue(rdpProperties);

                if (propertyValue == default)
                    continue;

                if (defaultValueAttribute != null && object.Equals(defaultValueAttribute.Value, propertyValue))
                    continue;

                if (allowedValuesAttribute != null)
                {
                    if (!allowedValuesAttribute.Values.Contains(propertyValue))
                    {
                        if (throwIfNotValid)
                            throw new InvalidOperationException($"The property '{propertyName}' has an unsupported value: {propertyValue}");
                    }
                }

                if (rangeAttribute != null)
                {
                    if (!IsWithinRange(rangeAttribute, (IComparable)propertyValue))
                    {
                        if (throwIfNotValid)
                            throw new InvalidOperationException($"The property '{propertyName}' has an out-of-range value: {propertyValue}.");
                    }
                }

                var serializedPropertyName = dataMemberAttribute.Name;

                if (serializedPropertyName == default)
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' does not have a valid serialized property name.");

                    continue;
                }

                var serializedTypeSign = string.Empty;
                var serializedPropertyValue = default(string);

                if (propertyType == typeof(byte) || propertyType == typeof(sbyte) ||
                    propertyType == typeof(short) || propertyType == typeof(ushort) ||
                    propertyType == typeof(int) || propertyType == typeof(uint) ||
                    propertyType == typeof(long) || propertyType == typeof(ulong))
                {
                    serializedTypeSign = "i";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else if (
                    propertyType == typeof(byte?) || propertyType == typeof(sbyte?) ||
                    propertyType == typeof(short?) || propertyType == typeof(ushort?) ||
                    propertyType == typeof(int?) || propertyType == typeof(uint?) ||
                    propertyType == typeof(long?) || propertyType == typeof(ulong?))
                {
                    serializedTypeSign = "i";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else if (
                    propertyType == typeof(char) || propertyType == typeof(char?) || propertyType == typeof(string) ||
                    propertyType == typeof(StringBuilder) || propertyType == typeof(Uri))
                {
                    serializedTypeSign = "s";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else if (propertyType == typeof(byte[]))
                {
                    serializedTypeSign = "b";
                    var byteArray = propertyValue as byte[] ?? new byte[0];
                    serializedPropertyValue = string.Concat(byteArray.Select(x => $"{x:X2}"));
                }
                else
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' have unsupported type '{propertyType}'.");

                    continue;
                }

                yield return $"{serializedPropertyName}:{serializedTypeSign}:{serializedPropertyValue}";
            }
        }

        /// <summary>
        /// Deserializes the specified RDP property lines to the specified type.
        /// </summary>
        /// <typeparam name="TRdpProperties">
        /// The type of the RDP properties.
        /// </typeparam>
        /// <param name="rdpPropertyLines">
        /// Serialized RDP properties.
        /// </param>
        /// <param name="throwIfNotValid">
        /// Throws an exception if the specified <paramref name="rdpPropertyLines"/> is not valid.
        /// </param>
        /// <returns>
        /// TRdpProperties instance.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Throws when the property does not have the DataMemberAttribute.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when the specified <paramref name="rdpPropertyLines"/> is not valid.
        /// </exception>
        public static TRdpProperties Deserialize<TRdpProperties>(IEnumerable<string> rdpPropertyLines, bool throwIfNotValid = true)
            where TRdpProperties : RemoteDesktopPropertiesBase, new()
        {
            var targetType = typeof(TRdpProperties);
            var targetTypeInfo = targetType.GetTypeInfo();

            if (targetTypeInfo.GetCustomAttribute<DataContractAttribute>() == default)
            {
                if (throwIfNotValid)
                    throw new InvalidOperationException($"Selected type '{typeof(TRdpProperties)}' does not have the DataContractAttribute.");

                return default;
            }

            var allProperties = targetType
                .GetRuntimeProperties()
                .ToArray();

            var propertyBindings = new Dictionary<string, PropertyInfo>();

            foreach (var eachProperty in allProperties)
            {
                var ignoreDataMemberAttribute = default(IgnoreDataMemberAttribute);
                var dataMemberAttribute = default(DataMemberAttribute);

                var propertyName = eachProperty.Name;
                var propertyType = eachProperty.PropertyType;

                foreach (var eachCustomAttribute in eachProperty.GetCustomAttributes(true))
                {
                    if (eachCustomAttribute is IgnoreDataMemberAttribute)
                        ignoreDataMemberAttribute = eachCustomAttribute as IgnoreDataMemberAttribute;
                    if (eachCustomAttribute is DataMemberAttribute)
                        dataMemberAttribute = eachCustomAttribute as DataMemberAttribute;
                }

                if (ignoreDataMemberAttribute != null)
                    continue;

                if (dataMemberAttribute == null || string.IsNullOrWhiteSpace(dataMemberAttribute.Name))
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' does not have DataMemberAttribute.");

                    continue;
                }

                propertyBindings.Add(dataMemberAttribute.Name, eachProperty);
            }

            var lineIndex = (-1);
            var instance = new TRdpProperties();
            var rdpRegex = Constants.RdpLineRegexFactory.Value;

            foreach (var eachPropertyLine in rdpPropertyLines)
            {
                lineIndex++;
                var match = rdpRegex.Match(eachPropertyLine);

                if (!match.Success)
                {
                    if (throwIfNotValid)
                        throw new ArgumentException($"Invalid data at line index {lineIndex} - {eachPropertyLine}");

                    continue;
                }

                var serializedPropertyName = match.Groups["PropertyName"].Value;
                var serializedTypeSign = match.Groups["TypeSign"].Value;
                var serializedPropertyValue = match.Groups["Rest"].Value;

                if (!propertyBindings.ContainsKey(serializedPropertyName))
                {
                    if (throwIfNotValid)
                        throw new ArgumentException($"Unknown property name '{serializedPropertyName}' at line index {lineIndex}.");

                    continue;
                }

                var targetProperty = propertyBindings[serializedPropertyName];
                var allowedValuesAttribute = targetProperty.GetCustomAttribute<RdpAllowedValuesAttribute>();
                var rangeAttribute = targetProperty.GetCustomAttribute<RangeAttribute>();
                var dataMemberAttribute = targetProperty.GetCustomAttribute<DataMemberAttribute>();
                var deserilaizedPropertyValue = default(object);

                switch (serializedTypeSign)
                {
                    case "i":
                        deserilaizedPropertyValue = Convert.ToInt32(serializedPropertyValue);
                        break;

                    case "s":
                        deserilaizedPropertyValue = Convert.ToString(serializedPropertyValue);
                        break;

                    case "b":
                        if (serializedPropertyValue.Length % 2 != 0)
                        {
                            if (throwIfNotValid)
                                throw new ArgumentException($"The property '{serializedPropertyName}' does not have even length at line index {lineIndex}.");

                            continue;
                        }

                        deserilaizedPropertyValue = Enumerable.Range(0, serializedPropertyValue.Length / 2).Select(x => Convert.ToByte(serializedPropertyValue.Substring(x * 2, 2), 16)).ToArray();
                        break;

                    default:
                        if (throwIfNotValid)
                            throw new ArgumentException($"Unknown property name '{serializedPropertyName}' at line index {lineIndex}.");

                        continue;
                }

                if (allowedValuesAttribute != null && !allowedValuesAttribute.IsValid(deserilaizedPropertyValue))
                {
                    if (throwIfNotValid)
                        throw new ArgumentException($"The property '{serializedPropertyName}' does not have valid value '{deserilaizedPropertyValue}' at line index {lineIndex}.");

                    continue;
                }

                if (rangeAttribute != null && !IsWithinRange(rangeAttribute, (IComparable)deserilaizedPropertyValue))
                {
                    if (throwIfNotValid)
                        throw new ArgumentException($"The property '{serializedPropertyName}' does not have valid value '{deserilaizedPropertyValue}' at line index {lineIndex}.");

                    continue;
                }

                targetProperty.SetValue(instance, deserilaizedPropertyValue);
            }

            return instance;
        }

        /// <summary>
        /// Serializes the specified <see cref="RemoteDesktopUriProperties"/> instance as RDP URI.
        /// </summary>
        /// <typeparam name="TRdpUriProperties">
        /// The type of the RDP URI properties.
        /// </typeparam>
        /// <param name="rdpUriProperties">
        /// RDP URI properties to serialize.
        /// </param>
        /// <param name="throwIfNotValid">
        /// Throws an exception if the specified <paramref name="rdpUriProperties"/> is not valid.
        /// </param>
        /// <returns>
        /// Serialized RDP URI string.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The specified <paramref name="rdpUriProperties"/> is not valid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Throws when the property does not have the DataMemberAttribute.
        /// </exception>
        public static string SerializeAsRdpUri<TRdpUriProperties>(this TRdpUriProperties rdpUriProperties, bool throwIfNotValid = true)
            where TRdpUriProperties : RemoteDesktopUriProperties
        {
            var fragments = new List<string>();
            var targetType = typeof(TRdpUriProperties);
            var targetTypeInfo = targetType.GetTypeInfo();
            var rdpLegacyUriScheme = "rdp://";

            if (targetTypeInfo.GetCustomAttribute<DataContractAttribute>() == default)
            {
                if (throwIfNotValid)
                    throw new ArgumentException($"Selected type '{typeof(TRdpUriProperties)}' does not have the DataContractAttribute.", nameof(rdpUriProperties));

                return rdpLegacyUriScheme;
            }

            var allProperties = targetType
                .GetRuntimeProperties()
                .ToArray();

            var fullAddressFragmentIndex = 0;
            var index = 0;

            foreach (var eachProperty in allProperties)
            {
                var ignoreDataMemberAttribute = default(IgnoreDataMemberAttribute);
                var allowedValuesAttribute = default(RdpAllowedValuesAttribute);
                var defaultValueAttribute = default(DefaultValueAttribute);
                var rangeAttribute = default(RangeAttribute);
                var dataMemberAttribute = default(DataMemberAttribute);

                var propertyName = eachProperty.Name;
                var propertyType = eachProperty.PropertyType;

                if (string.Equals(nameof(RemoteDesktopUriProperties.FullAddress), propertyName, StringComparison.Ordinal))
                    fullAddressFragmentIndex = index;

                foreach (var eachCustomAttribute in eachProperty.GetCustomAttributes(true))
                {
                    if (eachCustomAttribute is IgnoreDataMemberAttribute)
                        ignoreDataMemberAttribute = eachCustomAttribute as IgnoreDataMemberAttribute;
                    if (eachCustomAttribute is RdpAllowedValuesAttribute)
                        allowedValuesAttribute = eachCustomAttribute as RdpAllowedValuesAttribute;
                    if (eachCustomAttribute is DefaultValueAttribute)
                        defaultValueAttribute = eachCustomAttribute as DefaultValueAttribute;
                    if (eachCustomAttribute is RangeAttribute)
                        rangeAttribute = eachCustomAttribute as RangeAttribute;
                    if (eachCustomAttribute is DataMemberAttribute)
                        dataMemberAttribute = eachCustomAttribute as DataMemberAttribute;
                }

                if (ignoreDataMemberAttribute != null)
                    continue;

                if (dataMemberAttribute == null)
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' does not have DataMemberAttribute.");

                    continue;
                }

                var propertyValue = eachProperty.GetValue(rdpUriProperties);

                if (propertyValue == default)
                    continue;

                if (defaultValueAttribute != null && object.Equals(defaultValueAttribute.Value, propertyValue))
                    continue;

                if (allowedValuesAttribute != null)
                {
                    if (!allowedValuesAttribute.Values.Contains(propertyValue))
                    {
                        if (throwIfNotValid)
                            throw new InvalidOperationException($"The property '{propertyName}' has an unsupported value: {propertyValue}");
                    }
                }

                if (rangeAttribute != null)
                {
                    if (!IsWithinRange(rangeAttribute, (IComparable)propertyValue))
                    {
                        if (throwIfNotValid)
                            throw new InvalidOperationException($"The property '{propertyName}' has an out-of-range value: {propertyValue}.");
                    }
                }

                var serializedPropertyName = dataMemberAttribute.Name;

                if (serializedPropertyName == default)
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' does not have a valid serialized property name.");

                    continue;
                }

                var serializedTypeSign = string.Empty;
                var serializedPropertyValue = default(string);

                if (propertyType == typeof(byte) || propertyType == typeof(sbyte) ||
                    propertyType == typeof(short) || propertyType == typeof(ushort) ||
                    propertyType == typeof(int) || propertyType == typeof(uint) ||
                    propertyType == typeof(long) || propertyType == typeof(ulong))
                {
                    serializedTypeSign = "i";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else if (
                    propertyType == typeof(byte?) || propertyType == typeof(sbyte?) ||
                    propertyType == typeof(short?) || propertyType == typeof(ushort?) ||
                    propertyType == typeof(int?) || propertyType == typeof(uint?) ||
                    propertyType == typeof(long?) || propertyType == typeof(ulong?))
                {
                    serializedTypeSign = "i";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else if (
                    propertyType == typeof(char) || propertyType == typeof(char?) || propertyType == typeof(string) ||
                    propertyType == typeof(StringBuilder) || propertyType == typeof(Uri))
                {
                    serializedTypeSign = "s";
                    serializedPropertyValue = propertyValue?.ToString();
                }
                else
                {
                    if (throwIfNotValid)
                        throw new InvalidOperationException($"The property '{propertyName}' have unsupported type '{propertyType}'.");

                    continue;
                }

                fragments.Add($"{Uri.EscapeDataString(serializedPropertyName)}={Uri.EscapeDataString($"{serializedTypeSign}:{serializedPropertyValue}")}");
                index++;
            }

            if (fullAddressFragmentIndex > 0)
            {
                var fullAddressFragment = fragments[fullAddressFragmentIndex];
                fragments.RemoveAt(fullAddressFragmentIndex);
                fragments.Insert(0, fullAddressFragment);
            }

            return $"{rdpLegacyUriScheme}{string.Join("&", fragments)}";
        }

        private static bool IsWithinRange(RangeAttribute rangeAttribute, IComparable value)
        {
            return ((IComparable)rangeAttribute.Minimum).CompareTo(value) <= 0 &&
                value.CompareTo((IComparable)rangeAttribute.Maximum) <= 0;
        }
    }
}
