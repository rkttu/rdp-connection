using System.ComponentModel;
using System.Runtime.Serialization;

namespace RdpConnection
{
    /// <summary>
    /// Represents the properties of a Remote Desktop Service connection.
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior"/>
    /// </remarks>
    [DataContract]
    public class RemoteDesktopServiceProperties : RemoteDesktopPropertiesBase
    {
        /// <summary>
        /// Address of the remote computer.
        /// </summary>
        /// <remarks>
        /// This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.
        /// </remarks>
        [DisplayName("Address")]
        [Description("This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.")]
        [DataMember(Name = "full address")]
        public string FullAddress { get; set; }

        /// <summary>
        /// Alternate address of the remote computer.
        /// </summary>
        /// <remarks>
        /// Specifies an alternate name or IP address of the remote computer.
        /// </remarks>
        [DisplayName("Alternate full address")]
        [Description("Specifies an alternate name or IP address of the remote computer.")]
        [DataMember(Name = "alternate full address")]
        public string AlternateFullAddress { get; set; }

        /// <summary>
        /// Username of the user account.
        /// </summary>
        /// <remarks>
        /// Specifies the name of the user account that will be used to sign in to the remote computer.
        /// </remarks>
        [DisplayName("Username")]
        [Description("Specifies the name of the user account that will be used to sign in to the remote computer.")]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Domain of the user account.
        /// </summary>
        /// <remarks>
        /// Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.
        /// </remarks>
        [DisplayName("Domain")]
        [Description("Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.")]
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// RD Gateway hostname.
        /// </summary>
        /// <remarks>
        /// Specifies the RD Gateway host name.
        /// </remarks>
        [DisplayName("RD Gateway hostname")]
        [Description("Specifies the RD Gateway host name.")]
        [DataMember(Name = "gatewayhostname")]
        public string GatewayHostName { get; set; }

        /// <summary>
        /// RD Gateway usage method.
        /// </summary>
        /// <remarks>
        /// Specifies when to use an RD Gateway for the connection.
        /// </remarks>
        [DisplayName("RD Gateway authentication")]
        [Description("Specifies the RD Gateway authentication method.")]
        [RdpAllowedValues(0, 1, 2, 3, 4, 5)]
        [DataMember(Name = "gatewaycredentialssource")]
        public int? GatewayCredentialsSource { get; set; }

        /// <summary>
        /// RD Gateway profile usage method.
        /// </summary>
        /// <remarks>
        /// Specifies whether to use default RD Gateway settings.
        /// </remarks>
        [DisplayName("RD Gateway profile")]
        [Description("Specifies whether to use default RD Gateway settings.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "gatewayprofileusagemethod")]
        public int? GatewayProfileUsageMethod { get; set; }

        /// <summary>
        /// Use RD Gateway.
        /// </summary>
        /// <remarks>
        /// Specifies when to use an RD Gateway for the connection.
        /// </remarks>
        [DisplayName("Use RD Gateway")]
        [Description("Specifies when to use an RD Gateway for the connection.")]
        [RdpAllowedValues(0, 1, 2, 3, 4)]
        [DataMember(Name = "gatewayusagemethod")]
        public int? GatewayUsageMethod { get; set; }

        /// <summary>
        /// Whether to save credentials.
        /// </summary>
        /// <remarks>
        /// Determines whether a user's credentials are saved and used for both the RD Gateway and the remote computer.
        /// </remarks>
        [DisplayName("Save credentials")]
        [Description("Determines whether a user's credentials are saved and used for both the RD Gateway and the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "promptcredentialonce")]
        public int? PromptCredntialOnce { get; set; }

        /// <summary>
        /// Server authentication level.
        /// </summary>
        /// <remarks>
        /// Defines the server authentication level settings.
        /// </remarks>
        [DisplayName("Server authentication")]
        [Description("Defines the server authentication level settings.")]
        [RdpAllowedValues(0, 1, 2, 3)]
        [DataMember(Name = "authentication level")]
        public int? AuthenticationLevel { get; set; }

        /// <summary>
        /// Disable connection sharing.
        /// </summary>
        /// <remarks>
        /// Determines whether the client reconnects to any existing disconnected session or initiate a new connection when a new connection is launched.
        /// </remarks>
        [DisplayName("Disable connection sharing")]
        [Description("Determines whether the client reconnects to any existing disconnected session or initiate a new connection when a new connection is launched.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableconnectionsharing")]
        public int? DisableConnectionSharing { get; set; }

        /// <summary>
        /// Command-line parameters.
        /// </summary>
        /// <remarks>
        /// Optional command-line parameters for the RemoteApp.
        /// </remarks>
        [DisplayName("Command-line parameters")]
        [Description("Optional command-line parameters for the RemoteApp.")]
        [DataMember(Name = "remoteapplicationcmdline")]
        public string RemoteApplicationCommandLine { get; set; }

        /// <summary>
        /// Command-line variables.
        /// </summary>
        /// <remarks>
        /// Determines whether environment variables contained in the RemoteApp command-line parameter should be expanded locally or remotely.
        /// </remarks>
        [DisplayName("Command-line variables")]
        [Description("Determines whether environment variables contained in the RemoteApp command-line parameter should be expanded locally or remotely.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationexpandcmdline")]
        public int? RemoteApplicationExpandCommaneLine { get; set; }

        /// <summary>
        /// Working directory variables.
        /// </summary>
        /// <remarks>
        /// Determines whether environment variables contained in the RemoteApp working directory parameter should be expanded locally or remotely.
        /// </remarks>
        [DisplayName("Working directory variables")]
        [Description("Determines whether environment variables contained in the RemoteApp working directory parameter should be expanded locally or remotely.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationexpandworkingdir")]
        public int? RemoteApplicationExpandWorkingDirectory { get; set; }

        /// <summary>
        /// Open file.
        /// </summary>
        /// <remarks>
        /// Specifies a file to be opened on the remote computer by the RemoteApp. For local files to be opened, you must also enable drive redirection for the source drive.
        /// </remarks>
        [DisplayName("Open file")]
        [Description("Specifies a file to be opened on the remote computer by the RemoteApp. For local files to be opened, you must also enable drive redirection for the source drive.")]
        [DataMember(Name = "remoteapplicationfile")]
        public string RemoteApplicationFile { get; set; }

        /// <summary>
        /// Icon file.
        /// </summary>
        /// <remarks>
        /// Specifies the icon file to be displayed in the client UI while launching a RemoteApp. If no file name is specified, the client will use the standard Remote Desktop icon. Only .ico files are supported.
        /// </remarks>
        [DisplayName("Icon file")]
        [Description("Specifies the icon file to be displayed in the client UI while launching a RemoteApp. If no file name is specified, the client will use the standard Remote Desktop icon. Only .ico files are supported.")]
        [DataMember(Name = "remoteapplicationicon")]
        public string RemoteApplicationIcon { get; set; }

        /// <summary>
        /// Application mode.
        /// </summary>
        /// <remarks>
        /// Determines whether a connection is launched as a RemoteApp session.
        /// </remarks>
        [DisplayName("Application mode")]
        [Description("Determines whether a connection is launched as a RemoteApp session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationmode")]
        public int? RemoteApplicationMode { get; set; }

        /// <summary>
        /// Application display name.
        /// </summary>
        /// <remarks>
        /// Specifies the name of the RemoteApp in the client interface while starting the RemoteApp.
        /// </remarks>
        [DisplayName("Application display name")]
        [Description("Specifies the name of the RemoteApp in the client interface while starting the RemoteApp.")]
        [DataMember(Name = "remoteapplicationname")]
        public string RemoteApplicationName { get; set; }

        /// <summary>
        /// Alias/executable name.
        /// </summary>
        /// <remarks>
        /// Specifies the alias or executable name of the RemoteApp.
        /// </remarks>
        [DisplayName("Alias/executable name")]
        [Description("Specifies the alias or executable name of the RemoteApp.")]
        [DataMember(Name = "remoteapplicationprogram")]
        public string RemoteApplicationProgram { get; set; }
    }
}
