using System.ComponentModel;
using System.Runtime.Serialization;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior

    /// <summary>
    /// This class represents the properties of an Azure Virtual Desktop connection.
    /// </summary>
    [DataContract]
    public class AzureVirtualDesktopProperties : RemoteDesktopPropertiesBase
    {
        /// <summary>
        /// Connect to Microsoft Entra joined host
        /// </summary>
        /// <remarks>
        /// Allows connections to Microsoft Entra joined session hosts using username and password. Note that only applicable to non - Windows clients and local Windows devices that aren't joined to Microsoft Entra. This property is being replaced by the property enablerdsaadauth.
        /// </remarks>
        [DisplayName("Connect to Microsoft Entra joined host")]
        [Description("Allows connections to Microsoft Entra joined session hosts using username and password. Note that only applicable to non - Windows clients and local Windows devices that aren't joined to Microsoft Entra. This property is being replaced by the property enablerdsaadauth.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "targetisaadjoined")]
        public int? TargetIsAadJoined { get; set; }

        /// <summary>
        /// KDC proxy name
        /// </summary>
        /// <remarks>
        /// Specifies the fully qualified domain name of a KDC proxy.
        /// </remarks>
        [DisplayName("KDC proxy name")]
        [Description("Specifies the fully qualified domain name of a KDC proxy.")]
        [DataMember(Name = "kdcproxyname")]
        public string KdcProxyName { get; set; }
    }
}
