using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/remote-desktop-uri
    [DataContract]
    public class RemoteDesktopUriProperties
    {
        [DisplayName("Allow Desktop Composition")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow desktop composition")]
        public int? AllowDesktopComposition { get; set; }

        [DisplayName("Allow Font Smoothing")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow font smoothing")]
        public int? AllowFontSmoothing { get; set; }

        [DisplayName("Alternate shell")]
        [Description("Specifies a program to be started automatically in the remote session as the shell instead of explorer.")]
        [DataMember(Name = "alternate shell")]
        public string AlternateShell { get; set; }

        [DisplayName("Audio output location")]
        [Description("Determines whether the local or remote machine plays audio.")]
        [RdpAllowedValues(0, 1, 2)]
        [DataMember(Name = "audiomode")]
        public int? AudioMode { get; set; }

        [DisplayName("Server authentication")]
        [Description("Defines the server authentication level settings.")]
        [RdpAllowedValues(0, 1, 2, 3)]
        [DataMember(Name = "authentication level")]
        public int? AuthenticationLevel { get; set; }

        [DisplayName("Connect to console")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "connect to console")]
        public int? ConnectToConsole { get; set; }

        [DisplayName("Disable Cursor Settings")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable cursor setting")]
        public int? DisableCursorSettings { get; set; }

        [DisplayName("Disable Full Window Drag")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable full window drag")]
        public int? DisableFullWindowDrag { get; set; }

        [DisplayName("Disable Menu Animation Effects")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable menu anims")]
        public int? DisableMenuAnimations { get; set; }

        [DisplayName("Disable Theme")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable themes")]
        public int? DisableThemes { get; set; }

        [DisplayName("Disable Wallpaper")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable wallpaper")]
        public int? DisableWallpaper { get; set; }

        [DisplayName("Drive/storage redirection")]
        [Description("Determines which disk drives on the local computer will be redirected and available in the remote session.")]
        [DataMember(Name = "drivestoredirect")]
        public string DrivesToRedirect { get; set; }

        [DisplayName("Desktop height")]
        [Description("Specifies the resolution height (in pixels) of the remote session.")]
        [Range(200, 8192)]
        [DataMember(Name = "desktopheight")]
        public int? DesktopHeight { get; set; }

        [DisplayName("Desktop width")]
        [Description("Specifies the resolution width (in pixels) of the remote session.")]
        [Range(200, 8192)]
        [DataMember(Name = "desktopwidth")]
        public int? DesktopWidth { get; set; }

        [DisplayName("Domain")]
        [Description("Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.")]
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        [DisplayName("Address")]
        [Description("This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.")]
        [DataMember(Name = "full address")]
        public string FullAddress { get; set; }

        [DisplayName("RD Gateway hostname")]
        [Description("Specifies the RD Gateway host name.")]
        [DataMember(Name = "gatewayhostname")]
        public string GatewayHostName { get; set; }

        [DisplayName("Use RD Gateway")]
        [Description("Specifies when to use an RD Gateway for the connection.")]
        [RdpAllowedValues(0, 1, 2, 3, 4)]
        [DataMember(Name = "gatewayusagemethod")]
        public int? GatewayUsageMethod { get; set; }

        [DisplayName("Prompt for credentials on client")]
        [Description("This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "prompt for credentials on client")]
        public int? PromptForCredentialsOnClient { get; set; }

        [DisplayName("Load balance info")]
        [Description("This setting specifies the provider name, endpoint type, and an endpoint. Load-balancing information used to choose the best server for the client computer. For more information about LoadBalanceInfo, see (https://msdn.microsoft.com/en-us/library/aa381177(VS.85).aspx).")]
        [DataMember(Name = "loadbalanceinfo")]
        public string LoadBalanceInfo { get; set; }

        [DisplayName("Printer redirection")]
        [Description("Determines whether printers configured on the local computer will be redirected and available in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectprinters")]
        public int? RedirectPrinters { get; set; }

        [DisplayName("Command-line parameters")]
        [Description("Optional command-line parameters for the RemoteApp.")]
        [DataMember(Name = "remoteapplicationcmdline")]
        public string RemoteApplicationCommandLine { get; set; }

        [DisplayName("Application mode")]
        [Description("Determines whether a connection is launched as a RemoteApp session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "remoteapplicationmode")]
        public int? RemoteApplicationMode { get; set; }

        [DisplayName("Sehll Working Directory")]
        [Description("To Do: Need to add a description for a property")]
        [DataMember(Name = "shell working directory")]
        public string ShellWorkingDirectory { get; set; }

        [DisplayName("Use Redirection Server Name")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "Use redirection server name")]
        public int? UseRedirectionServerName { get; set; }

        [DisplayName("Username")]
        [Description("Specifies the name of the user account that will be used to sign in to the remote computer.")]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DisplayName("Screen mode")]
        [Description("Determines whether the remote session window appears full screen when you launch the connection.")]
        [RdpAllowedValues(1, 2)]
        [DataMember(Name = "screen mode id")]
        public int? ScreenModeId { get; set; }

        [DisplayName("Session Bpp")]
        [Description("This setting determines the color depth on the remote computer when you connect by using Remote Desktop Connection (RDC). This setting corresponds to the selection in the Colors drop - down list on the Display tab under Options in RDC.")]
        [RdpAllowedValues(8, 15, 16, 24, 32)]
        [DataMember(Name = "session bpp")]
        public int? SessionBpp { get; set; }

        [DisplayName("Multiple displays")]
        [Description("Determines whether the remote session will use one or multiple displays from the local computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "use multimon")]
        public int? UseMultipleMonitors { get; set; }
    }
}
