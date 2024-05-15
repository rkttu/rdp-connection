using System.ComponentModel;
using System.Runtime.Serialization;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior
    [DataContract]
    public class AzureVirtualDesktopProperties : RemoteDesktopPropertiesBase
    {
        [DisplayName("Connect to Microsoft Entra joined host")]
        [Description("Allows connections to Microsoft Entra joined session hosts using username and password. Note that only applicable to non - Windows clients and local Windows devices that aren't joined to Microsoft Entra. This property is being replaced by the property enablerdsaadauth.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "targetisaadjoined")]
        public int? TargetIsAadJoined { get; set; }

        [DisplayName("KDC proxy name")]
        [Description("Specifies the fully qualified domain name of a KDC proxy.")]
        [DataMember(Name = "kdcproxyname")]
        public string KdcProxyName { get; set; }
    }
}
