using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RdpConnection
{
    /// <summary>
    /// Represents the properties of a Remote Desktop connection URI.
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/remote-desktop-uri"/>
    /// </remarks>
    [DataContract]
    public class RemoteDesktopUriProperties
    {
        /// <summary>
        /// Address
        /// </summary>
        /// <remarks>
        /// This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.
        /// </remarks>
        [DisplayName("Address")]
        [Description("This setting specifies the hostname or IP address of the remote computer that you want to connect to. This is the only required setting in an RDP file.")]
        [DataMember(Name = "full address")]
        public string FullAddress { get; set; }

        /// <summary>
        /// Allow Desktop Composition
        /// </summary>
        /// <remarks>
        /// This setting determines whether desktop composition is allowed in the remote session. Desktop composition is a feature in Windows that allows apps to draw better quality images on the screen. This setting corresponds to the Allow desktop composition check box on the Experience tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Allow Desktop Composition")]
        [Description("This setting determines whether desktop composition is allowed in the remote session. Desktop composition is a feature in Windows that allows apps to draw better quality images on the screen. This setting corresponds to the Allow desktop composition check box on the Experience tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow desktop composition")]
        public int? AllowDesktopComposition { get; set; }

        /// <summary>
        /// Allow Font Smoothing
        /// </summary>
        /// <remarks>
        /// This setting determines whether font smoothing is allowed in the remote session. Font smoothing is a feature in Windows that makes fonts appear smoother on the screen. This setting corresponds to the Allow font smoothing check box on the Experience tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Allow Font Smoothing")]
        [Description("This setting determines whether font smoothing is allowed in the remote session. Font smoothing is a feature in Windows that makes fonts appear smoother on the screen. This setting corresponds to the Allow font smoothing check box on the Experience tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow font smoothing")]
        public int? AllowFontSmoothing { get; set; }

        /// <summary>
        /// Alternate shell
        /// </summary>
        /// <remarks>
        /// Specifies a program to be started automatically in the remote session as the shell instead of explorer.
        /// </remarks>
        [DisplayName("Alternate shell")]
        [Description("Specifies a program to be started automatically in the remote session as the shell instead of explorer.")]
        [DataMember(Name = "alternate shell")]
        public string AlternateShell { get; set; }

        /// <summary>
        /// Audio output location
        /// </summary>
        /// <remarks>
        /// Determines whether the local or remote machine plays audio.
        /// </remarks>
        [DisplayName("Audio output location")]
        [Description("Determines whether the local or remote machine plays audio.")]
        [RdpAllowedValues(0, 1, 2)]
        [DataMember(Name = "audiomode")]
        public int? AudioMode { get; set; }

        /// <summary>
        /// Server authentication
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
        /// Connect to console
        /// </summary>
        /// <remarks>
        /// This setting determines whether the remote session connects to the console session of the remote computer. The console session is the session that is physically connected to the computer. This setting corresponds to the Connect to console check box on the General tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Connect to console")]
        [Description("This setting determines whether the remote session connects to the console session of the remote computer. The console session is the session that is physically connected to the computer. This setting corresponds to the Connect to console check box on the General tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "connect to console")]
        public int? ConnectToConsole { get; set; }

        /// <summary>
        /// Disable cursor settings
        /// </summary>
        /// <remarks>
        /// This setting determines whether cursor settings are disabled in the remote session. Cursor settings include cursor blinking, cursor shadow, and cursor trails. This setting corresponds to the Display the pointer trails check box on the Pointer tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Disable Cursor Settings")]
        [Description("This setting determines whether cursor settings are disabled in the remote session. Cursor settings include cursor blinking, cursor shadow, and cursor trails. This setting corresponds to the Display the pointer trails check box on the Pointer tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable cursor setting")]
        public int? DisableCursorSettings { get; set; }

        /// <summary>
        /// Disable full window drag
        /// </summary>
        /// <remarks>
        /// This setting determines whether full window drag is disabled in the remote session. Full window drag is a feature in Windows that allows you to move a window by dragging the window's title bar. This setting corresponds to the Display the pointer trails check box on the Pointer tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Disable Full Window Drag")]
        [Description("This setting determines whether full window drag is disabled in the remote session. Full window drag is a feature in Windows that allows you to move a window by dragging the window's title bar. This setting corresponds to the Display the pointer trails check box on the Pointer tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable full window drag")]
        public int? DisableFullWindowDrag { get; set; }

        /// <summary>
        /// Disable menu animation effects
        /// </summary>
        /// <remarks>
        /// This setting determines whether menu animation effects are disabled in the remote session. Menu animation effects include fading or sliding menus. This setting corresponds to the Show window contents while dragging check box on the Experience tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Disable Menu Animation Effects")]
        [Description("This setting determines whether menu animation effects are disabled in the remote session. Menu animation effects include fading or sliding menus. This setting corresponds to the Show window contents while dragging check box on the Experience tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable menu anims")]
        public int? DisableMenuAnimations { get; set; }

        /// <summary>
        /// Disable themes
        /// </summary>
        /// <remarks>
        /// This setting determines whether themes are disabled in the remote session. Themes include visual styles, background images, and colors. This setting corresponds to the Themes check box on the Experience tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Disable Theme")]
        [Description("This setting determines whether themes are disabled in the remote session. Themes include visual styles, background images, and colors. This setting corresponds to the Themes check box on the Experience tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable themes")]
        public int? DisableThemes { get; set; }

        /// <summary>
        /// Disable wallpaper
        /// </summary>
        /// <remarks>
        /// This setting determines whether wallpaper is disabled in the remote session. Wallpaper includes background images and colors. This setting corresponds to the Desktop background check box on the Experience tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Disable Wallpaper")]
        [Description("This setting determines whether wallpaper is disabled in the remote session. Wallpaper includes background images and colors. This setting corresponds to the Desktop background check box on the Experience tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable wallpaper")]
        public int? DisableWallpaper { get; set; }

        /// <summary>
        /// Drives to redirect
        /// </summary>
        /// <remarks>
        /// Determines which disk drives on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Drive/storage redirection")]
        [Description("Determines which disk drives on the local computer will be redirected and available in the remote session.")]
        [DataMember(Name = "drivestoredirect")]
        public string DrivesToRedirect { get; set; }

        /// <summary>
        /// Desktop height
        /// </summary>
        /// <remarks>
        /// Specifies the resolution height (in pixels) of the remote session.
        /// </remarks>
        [DisplayName("Desktop height")]
        [Description("Specifies the resolution height (in pixels) of the remote session.")]
        [Range(200, 8192)]
        [DataMember(Name = "desktopheight")]
        public int? DesktopHeight { get; set; }

        /// <summary>
        /// Desktop width
        /// </summary>
        /// <remarks>
        /// Specifies the resolution width (in pixels) of the remote session.
        /// </remarks>
        [DisplayName("Desktop width")]
        [Description("Specifies the resolution width (in pixels) of the remote session.")]
        [Range(200, 8192)]
        [DataMember(Name = "desktopwidth")]
        public int? DesktopWidth { get; set; }

        /// <summary>
        /// Domain
        /// </summary>
        /// <remarks>
        /// Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.
        /// </remarks>
        [DisplayName("Domain")]
        [Description("Specifies the name of the domain in which the user account that will be used to sign in to the remote computer is located.")]
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// RD Gateway hostname
        /// </summary>
        /// <remarks>
        /// Specifies the RD Gateway host name.
        /// </remarks>
        [DisplayName("RD Gateway hostname")]
        [Description("Specifies the RD Gateway host name.")]
        [DataMember(Name = "gatewayhostname")]
        public string GatewayHostName { get; set; }

        /// <summary>
        /// Gateway profile usage
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
        /// Prompt for credentials on client
        /// </summary>
        /// <remarks>
        /// This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.
        /// </remarks>
        [DisplayName("Prompt for credentials on client")]
        [Description("This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "prompt for credentials on client")]
        public int? PromptForCredentialsOnClient { get; set; }

        /// <summary>
        /// Load balance info
        /// </summary>
        /// <remarks>
        /// This setting specifies the provider name, endpoint type, and an endpoint. Load-balancing information used to choose the best server for the client computer. For more information about LoadBalanceInfo, see (https://msdn.microsoft.com/en-us/library/aa381177(VS.85).aspx).
        /// </remarks>
        [DisplayName("Load balance info")]
        [Description("This setting specifies the provider name, endpoint type, and an endpoint. Load-balancing information used to choose the best server for the client computer. For more information about LoadBalanceInfo, see (https://msdn.microsoft.com/en-us/library/aa381177(VS.85).aspx).")]
        [DataMember(Name = "loadbalanceinfo")]
        public string LoadBalanceInfo { get; set; }

        /// <summary>
        /// Printer redirection
        /// </summary>
        /// <remarks>
        /// Determines whether printers configured on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Printer redirection")]
        [Description("Determines whether printers configured on the local computer will be redirected and available in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectprinters")]
        public int? RedirectPrinters { get; set; }

        /// <summary>
        /// Command-line parameters
        /// </summary>
        /// <remarks>
        /// Optional command-line parameters for the RemoteApp.
        /// </remarks>
        [DisplayName("Command-line parameters")]
        [Description("Optional command-line parameters for the RemoteApp.")]
        [DataMember(Name = "remoteapplicationcmdline")]
        public string RemoteApplicationCommandLine { get; set; }

        /// <summary>
        /// Application mode
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
        /// Shell working directory
        /// </summary>
        /// <remarks>
        /// This setting specifies the starting directory for the RemoteApp.
        /// </remarks>
        [DisplayName("Sehll Working Directory")]
        [Description("This setting specifies the starting directory for the RemoteApp.")]
        [DataMember(Name = "shell working directory")]
        public string ShellWorkingDirectory { get; set; }

        /// <summary>
        /// Use redirection server name
        /// </summary>
        /// <remarks>
        /// This setting determines whether the redirection server name is used in the remote session.
        /// </remarks>
        [DisplayName("Use Redirection Server Name")]
        [Description("This setting determines whether the redirection server name is used in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "Use redirection server name")]
        public int? UseRedirectionServerName { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        /// <remarks>
        /// Specifies the name of the user account that will be used to sign in to the remote computer.
        /// </remarks>
        [DisplayName("Username")]
        [Description("Specifies the name of the user account that will be used to sign in to the remote computer.")]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Screen mode
        /// </summary>
        /// <remarks>
        /// Determines whether the remote session window appears full screen when you launch the connection.
        /// </remarks>
        [DisplayName("Screen mode")]
        [Description("Determines whether the remote session window appears full screen when you launch the connection.")]
        [RdpAllowedValues(1, 2)]
        [DataMember(Name = "screen mode id")]
        public int? ScreenModeId { get; set; }

        /// <summary>
        /// Session Bpp
        /// </summary>
        /// <remarks>
        /// This setting determines the color depth on the remote computer when you connect by using Remote Desktop Connection (RDC). This setting corresponds to the selection in the Colors drop-down list on the Display tab under Options in RDC.
        /// </remarks>
        [DisplayName("Session Bpp")]
        [Description("This setting determines the color depth on the remote computer when you connect by using Remote Desktop Connection (RDC). This setting corresponds to the selection in the Colors drop - down list on the Display tab under Options in RDC.")]
        [RdpAllowedValues(8, 15, 16, 24, 32)]
        [DataMember(Name = "session bpp")]
        public int? SessionBpp { get; set; }

        /// <summary>
        /// Multiple displays
        /// </summary>
        /// <remarks>
        /// Determines whether the remote session will use one or multiple displays from the local computer.
        /// </remarks>
        [DisplayName("Multiple displays")]
        [Description("Determines whether the remote session will use one or multiple displays from the local computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "use multimon")]
        public int? UseMultipleMonitors { get; set; }
    }
}
