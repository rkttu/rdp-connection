using System.ComponentModel;
using System.Runtime.Serialization;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior
    [DataContract]
    public class RemoteDesktopServiceProperties : RemoteDesktopPropertiesBase
    {
        [DisplayName("Address")]
        [Description("This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.")]
        [DataMember(Name = "full address")]
        public string FullAddress { get; set; }

        [DisplayName("Alternate full address")]
        [Description("Specifies an alternate name or IP address of the remote computer.")]
        [DataMember(Name = "alternate full address")]
        public string AlternateFullAddress { get; set; }

        [DisplayName("Username")]
        [Description("Specifies the name of the user account that will be used to sign in to the remote computer.")]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DisplayName("Domain")]
        [Description("Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.")]
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        [DisplayName("RD Gateway hostname")]
        [Description("Specifies the RD Gateway host name.")]
        [DataMember(Name = "gatewayhostname")]
        public string GatewayHostName { get; set; }

        [DisplayName("RD Gateway authentication")]
        [Description("Specifies the RD Gateway authentication method.")]
        [RdpAllowedValues(0, 1, 2, 3, 4, 5)]
        [DataMember(Name = "gatewaycredentialssource")]
        public int? GatewayCredentialsSource { get; set; }

        [DisplayName("RD Gateway profile")]
        [Description("Specifies whether to use default RD Gateway settings.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "gatewayprofileusagemethod")]
        public int? GatewayProfileUsageMethod { get; set; }

        [DisplayName("Use RD Gateway")]
        [Description("Specifies when to use an RD Gateway for the connection.")]
        [RdpAllowedValues(0, 1, 2, 3, 4)]
        [DataMember(Name = "gatewayusagemethod")]
        public int? GatewayUsageMethod { get; set; }

        [DisplayName("Save credentials")]
        [Description("Determines whether a user's credentials are saved and used for both the RD Gateway and the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "promptcredentialonce")]
        public int? PromptCredntialOnce { get; set; }

        [DisplayName("Server authentication")]
        [Description("Defines the server authentication level settings.")]
        [RdpAllowedValues(0, 1, 2, 3)]
        [DataMember(Name = "authentication level")]
        public int? AuthenticationLevel { get; set; }

        [DisplayName("Connection sharing")]
        [Description("Determines whether the client reconnects to any existing disconnected session or initiate a new connection when a new connection is launched.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableconnectionsharing")]
        public int? DisableConnectionSharing { get; set; }

        [DisplayName("Command-line parameters")]
        [Description("Optional command-line parameters for the RemoteApp.")]
        [DataMember(Name = "remoteapplicationcmdline")]
        public string RemoteApplicationCommandLine { get; set; }

        [DisplayName("Command-line variables")]
        [Description("Determines whether environment variables contained in the RemoteApp command-line parameter should be expanded locally or remotely.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationexpandcmdline")]
        public int? RemoteApplicationExpandCommaneLine { get; set; }

        [DisplayName("Working directory variables")]
        [Description("Determines whether environment variables contained in the RemoteApp working directory parameter should be expanded locally or remotely.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationexpandworkingdir")]
        public int? RemoteApplicationExpandWorkingDirectory { get; set; }

        [DisplayName("Open file")]
        [Description("Specifies a file to be opened on the remote computer by the RemoteApp. For local files to be opened, you must also enable drive redirection for the source drive.")]
        [DataMember(Name = "remoteapplicationfile")]
        public string RemoteApplicationFile { get; set; }

        [DisplayName("Icon file")]
        [Description("Specifies the icon file to be displayed in the client UI while launching a RemoteApp. If no file name is specified, the client will use the standard Remote Desktop icon. Only .ico files are supported.")]
        [DataMember(Name = "remoteapplicationicon")]
        public string RemoteApplicationIcon { get; set; }

        [DisplayName("Application mode")]
        [Description("Determines whether a connection is launched as a RemoteApp session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationmode")]
        public int? RemoteApplicationMode { get; set; }

        [DisplayName("Application display name")]
        [Description("Specifies the name of the RemoteApp in the client interface while starting the RemoteApp.")]
        [DataMember(Name = "remoteapplicationname")]
        public string RemoteApplicationName { get; set; }

        [DisplayName("Alias/executable name")]
        [Description("Specifies the alias or executable name of the RemoteApp.")]
        [DataMember(Name = "remoteapplicationprogram")]
        public string RemoteApplicationProgram { get; set; }
    }
}
