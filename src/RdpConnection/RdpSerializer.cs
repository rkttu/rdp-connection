using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RdpConnection;

public static class RdpSerializer
{
    public static IEnumerable<string> Serialize<TRdpProperties>(this TRdpProperties? rdpProperties, bool throwIfNotValid = true)
        where TRdpProperties : RemoteDesktopServicePropertiesBase
    {
        if (rdpProperties == default)
            yield break;

        var targetType = typeof(TRdpProperties);

        if (targetType.GetCustomAttribute<DataContractAttribute>() == default)
        {
            if (throwIfNotValid)
                throw new ArgumentException($"Selected type '{typeof(TRdpProperties)}' does not have the DataContractAttribute.", nameof(rdpProperties));

            yield break;
        }

        var allProperties = targetType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToArray();

        foreach (var eachProperty in allProperties)
        {
            var ignoreDataMemberAttribute = default(IgnoreDataMemberAttribute);
            var allowedValuesAttribute = default(AllowedValuesAttribute);
            var defaultValueAttribute = default(DefaultValueAttribute);
            var rangeAttribute = default(RangeAttribute);
            var dataMemberAttribute = default(DataMemberAttribute);

            var propertyName = eachProperty.Name;
            var propertyType = eachProperty.PropertyType;

            foreach (var eachCustomAttribute in eachProperty.GetCustomAttributes(true))
            {
                if (eachCustomAttribute is IgnoreDataMemberAttribute)
                    ignoreDataMemberAttribute = eachCustomAttribute as IgnoreDataMemberAttribute;
                if (eachCustomAttribute is AllowedValuesAttribute)
                    allowedValuesAttribute = eachCustomAttribute as AllowedValuesAttribute;
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
                if (!rangeAttribute.IsValid(propertyValue))
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
                propertyType == typeof(StringBuilder) || propertyType == typeof(Uri) ||
                propertyType == typeof(IPAddress) || propertyType == typeof(IPEndPoint))
            {
                serializedTypeSign = "s";
                serializedPropertyValue = propertyValue?.ToString();
            }
            else if (propertyType == typeof(byte[]))
            {
                serializedTypeSign = "b";
                var byteArray = new byte[] { };

                if (string.Equals("password 51", propertyName, StringComparison.Ordinal) &&
                    Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
#pragma warning disable CA1416
                    var optionalEntropy = default(byte[]);
                    var protectionScope = DataProtectionScope.CurrentUser;
                    byteArray = ProtectedData.Protect(byteArray, optionalEntropy, protectionScope);
#pragma warning restore CA1416
                }
                else
                    byteArray = propertyValue as byte[] ?? new byte[0];

                serializedPropertyValue = string.Concat();
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

    public static TRdpProperties? Deserialize<TRdpProperties>(IEnumerable<string> rdpPropertyLines, bool throwIfNotValid = true)
        where TRdpProperties : RemoteDesktopServicePropertiesBase, new()
    {
        var targetType = typeof(TRdpProperties);

        if (targetType.GetCustomAttribute<DataContractAttribute>() == default)
        {
            if (throwIfNotValid)
                throw new InvalidOperationException($"Selected type '{typeof(TRdpProperties)}' does not have the DataContractAttribute.");

            return default;
        }

        var allProperties = targetType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
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

        foreach (var eachPropertyLine in rdpPropertyLines)
        {
            lineIndex++;

            var match = Regex.Match(eachPropertyLine, "(?<PropertyName>[^:]+):(?<TypeSign>[^:]+):(?<Rest>[^\r\n]*)", RegexOptions.Compiled);

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
            var allowedValuesAttribute = targetProperty.GetCustomAttribute<AllowedValuesAttribute>();
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

            if (rangeAttribute != null && !rangeAttribute.IsValid(deserilaizedPropertyValue))
            {
                if (throwIfNotValid)
                    throw new ArgumentException($"The property '{serializedPropertyName}' does not have valid value '{deserilaizedPropertyValue}' at line index {lineIndex}.");

                continue;
            }

            targetProperty.SetValue(instance, deserilaizedPropertyValue);
        }

        return instance;
    }

    public static string SerializeAsRdpUri<TRdpUriProperties>(this TRdpUriProperties rdpUriProperties, bool throwIfNotValid = true)
        where TRdpUriProperties : RemoteDesktopUriProperties
    {
        var fragments = new List<string>();
        var targetType = typeof(TRdpUriProperties);
        var rdpLegacyUriScheme = "rdp://";

        if (targetType.GetCustomAttribute<DataContractAttribute>() == default)
        {
            if (throwIfNotValid)
                throw new ArgumentException($"Selected type '{typeof(TRdpUriProperties)}' does not have the DataContractAttribute.", nameof(rdpUriProperties));

            return rdpLegacyUriScheme;
        }

        var allProperties = targetType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToArray();

        var fullAddressFragmentIndex = 0;
        var index = 0;

        foreach (var eachProperty in allProperties)
        {
            var ignoreDataMemberAttribute = default(IgnoreDataMemberAttribute);
            var allowedValuesAttribute = default(AllowedValuesAttribute);
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
                if (eachCustomAttribute is AllowedValuesAttribute)
                    allowedValuesAttribute = eachCustomAttribute as AllowedValuesAttribute;
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
                if (!rangeAttribute.IsValid(propertyValue))
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
                propertyType == typeof(StringBuilder) || propertyType == typeof(Uri) ||
                propertyType == typeof(IPAddress) || propertyType == typeof(IPEndPoint))
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

        return $"{rdpLegacyUriScheme}{string.Join('&', fragments)}";
    }
}
