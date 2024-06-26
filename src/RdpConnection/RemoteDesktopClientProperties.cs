﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RdpConnection
{
    /// <summary>
    /// Represents the properties of a Remote Desktop Connection (RDC) client.
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-r2-and-2008/ff393699(v=ws.10)"/>
    /// </remarks>
    [DataContract]
    public class RemoteDesktopClientProperties : RemoteDesktopServiceProperties
    {
        /// <summary>
        /// Administrative session
        /// </summary>
        /// <remarks>
        /// This setting configures the client computer to connect to the administrative session of the remote computer. This setting is the same as the /admin parameter used with mstsc.exe.
        /// </remarks>
        [DisplayName("Administrative session")]
        [Description("This setting configures the client computer to connect to the administrative session of the remote computer. This setting is the same as the /admin parameter used with mstsc.exe.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "administrative session")]
        public int? AdministrativeSession { get; set; }

        /// <summary>
        /// Allow desktop composition
        /// </summary>
        /// <remarks>
        /// This setting determines whether desktop composition is enabled on the remote computer. Desktop composition is a feature in Windows that allows you to view the desktop as if it were a three-dimensional space. Desktop composition is also known as Aero Glass.
        /// </remarks>
        [DisplayName("Allow Desktop Composition")]
        [Description("This setting determines whether desktop composition is enabled on the remote computer. Desktop composition is a feature in Windows that allows you to view the desktop as if it were a three-dimensional space. Desktop composition is also known as Aero Glass.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow desktop composition")]
        public int? AllowDesktopComposition { get; set; }

        /// <summary>
        /// Allow font smoothing
        /// </summary>
        /// <remarks>
        /// This setting determines whether font smoothing is enabled on the remote computer. Font smoothing is a feature in Windows that makes fonts appear smoother on the screen.
        /// </remarks>
        [DisplayName("Allow Font Smoothing")]
        [Description("This setting determines whether font smoothing is enabled on the remote computer. Font smoothing is a feature in Windows that makes fonts appear smoother on the screen.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "allow font smoothing")]
        public int? AllowFontSmoothing { get; set; }

        /// <summary>
        /// Audio quality mode
        /// </summary>
        /// <remarks>
        /// This setting determines the audio playback quality on the local computer.
        /// </remarks>
        [DisplayName("Audio Quality Mode")]
        [Description("This setting determines the audio playback quality on the local computer.")]
        [RdpAllowedValues(0, 1, 2)]
        [DataMember(Name = "audioqualitymode")]
        public int? AudioQualityMode { get; set; }

        /// <summary>
        /// Auto reconnect max retries
        /// </summary>
        /// <remarks>
        /// This setting determines the maximum number of times the client computer will automatically try to reconnect to the remote computer if the connection is dropped, for example, when there is an interruption of network connectivity.
        /// </remarks>
        [DisplayName("Auto reconnect max retries")]
        [Description("This setting determines the maximum number of times the client computer will automatically try to reconnect to the remote computer if the connection is dropped, for example, when there is an interruption of network connectivity.")]
        [Range(0, Int32.MaxValue)]
        [DataMember(Name = "autoreconnect max retries")]
        public int? AutoReconnectMaxRetries { get; set; }

        /// <summary>
        /// Bitmap cache persist enabled
        /// </summary>
        /// <remarks>
        /// This setting determines whether bitmaps are cached on the local computer. Bitmap caching can improve the performance of your remote session by storing frequently used images on the local computer.
        /// </remarks>
        [DisplayName("Bitmap Cache Persist Enabled")]
        [Description("This setting determines whether bitmaps are cached on the local computer. Bitmap caching can improve the performance of your remote session by storing frequently used images on the local computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "bitmapcachepersistenable")]
        public int? BitmapCachePersistEnable { get; set; }

        /// <summary>
        /// Connection type
        /// </summary>
        /// <remarks>
        /// This setting configures the client computer’s connection speed. This setting corresponds to the selections for Choose your connection speed to optimize performance on the Experience tab under Options in Remote Desktop Connection.
        /// </remarks>
        [DisplayName("Connection Type")]
        [Description("This setting configures the client computer’s connection speed. This setting corresponds to the selections for Choose your connection speed to optimize performance on the Experience tab under Options in Remote Desktop Connection.")]
        [RdpAllowedValues(1, 2, 3, 4, 5, 6, 7)]
        [DataMember(Name = "connection type")]
        public int? ConnectionType { get; set; }

        /// <summary>
        /// Disable Ctrl + Alt + Delete
        /// </summary>
        /// <remarks>
        /// This setting determines whether the CTRL+ALT+DELETE security attention sequence is required to enter credentials after you are connected to the remote computer.
        /// </remarks>
        [DisplayName("Disable Ctrl + Alt + Delete")]
        [Description("This setting determines whether the CTRL+ALT+DELETE security attention sequence is required to enter credentials after you are connected to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable ctrl+alt+del")]
        public int? DisableCtrlAltDel { get; set; }

        /// <summary>
        /// Disable Printer Redirection
        /// </summary>
        /// <remarks>
        /// This setting determines whether Easy Print printer redirection is enabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Printer Redirection")]
        [Description("This setting determines whether Easy Print printer redirection is enabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableprinterredirection")]
        public int? DisablePrinterRedirection { get; set; }

        /// <summary>
        /// Disable Clipboard Redirection
        /// </summary>
        /// <remarks>
        /// This setting determines whether Clipboard redirection is enabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Clipboard Redirection")]
        [Description("This setting determines whether Clipboard redirection is enabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableclipboardredirection")]
        public int? DisableClipboardRedirection { get; set; }

        /// <summary>
        /// Disable Cursor Settings
        /// </summary>
        /// <remarks>
        /// This setting determines whether the cursor settings are disabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Cursor Settings")]
        [Description("This setting determines whether the cursor settings are disabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable cursor setting")]
        public int? DisableCursorSettings { get; set; }

        /// <summary>
        /// Disable Wallpaper
        /// </summary>
        /// <remarks>
        /// This setting determines whether the wallpaper is disabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Wallpaper")]
        [Description("This setting determines whether the wallpaper is disabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable wallpaper")]
        public int? DisableWallpaper { get; set; }

        /// <summary>
        /// Disable Full Window Drag
        /// </summary>
        /// <remarks>
        /// This setting determines whether full window drag is disabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Full Window Drag")]
        [Description("This setting determines whether full window drag is disabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable full window drag")]
        public int? DisableFullWindowDrag { get; set; }

        /// <summary>
        /// Disable Menu Animation Effects
        /// </summary>
        /// <remarks>
        /// This setting determines whether menu animation effects are disabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Menu Animation Effects")]
        [Description("This setting determines whether menu animation effects are disabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable menu anims")]
        public int? DisableMenuAnimations { get; set; }

        /// <summary>
        /// Disable Themes
        /// </summary>
        /// <remarks>
        /// This setting determines whether themes are disabled when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Disable Theme")]
        [Description("This setting determines whether themes are disabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable themes")]
        public int? DisableThemes { get; set; }

        /// <summary>
        /// Display Connection Bar
        /// </summary>
        /// <remarks>
        /// This setting determines whether the connection bar appears when you are in full screen mode when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the Display the connection bar when I use the full screen check box on the Display tab under Options in RDC.
        /// </remarks>
        [DisplayName("Display Connection Bar")]
        [Description("This setting determines whether the connection bar appears when you are in full screen mode when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the Display the connection bar when I use the full screen check box on the Display tab under Options in RDC.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "displayconnectionbar")]
        public int? DisplayConnectionBar { get; set; }

        /// <summary>
        /// Enable Workspace Reconnect
        /// </summary>
        /// <remarks>
        /// This setting determines whether the client computer will attempt to reconnect to the remote computer if the connection is dropped. This setting corresponds to the Reconnect if the connection is dropped check box on the General tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Enable Workspace Reconnect")]
        [Description("This setting determines whether the client computer will attempt to reconnect to the remote computer if the connection is dropped. This setting corresponds to the Reconnect if the connection is dropped check box on the General tab under Options in Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "enableworkspacereconnect")]
        public int? EnableWorkspaceReconnect { get; set; }

        /// <summary>
        /// Gateway Brokering Type
        /// </summary>
        /// <remarks>
        /// This setting determines the type of gateway brokering that will be used when connecting to the remote computer. This setting corresponds to the Gateway brokering type drop-down list on the Advanced tab under Options in Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Gateway Brokering Type")]
        [Description("This setting determines the type of gateway brokering that will be used when connecting to the remote computer. This setting corresponds to the Gateway brokering type drop-down list on the Advanced tab under Options in Remote Desktop Connection (RDC).")]
        [DataMember(Name = "gatewaybrokeringtype")]
        public int? GatewayBrokeringType { get; set; }

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
        /// Negotiate Security Layer
        /// </summary>
        /// <remarks>
        /// This setting determines whether or not RDP negotiates the security layer.
        /// </remarks>
        [DisplayName("Negotiate Security Layer")]
        [Description("This setting determines whether or not RDP negotiates the security layer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "negotiate security layer")]
        public int? NegotiateSecurityLayer { get; set; }

        /// <summary>
        /// Pin Connection Bar
        /// </summary>
        /// <remarks>
        /// This setting determines whether or not the connection bar should be pinned to the top of the remote session upon connection.
        /// </remarks>
        [DisplayName("Pin Connection Bar")]
        [Description("This setting determines whether or not the connection bar should be pinned to the top of the remote session upon connection.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "pinconnectionbar")]
        public int? PinConnectionBar { get; set; }

        /// <summary>
        /// Prompt for credentials
        /// </summary>
        /// <remarks>
        /// This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.
        /// </remarks>
        [DisplayName("Prompt for credentials")]
        [Description("This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "prompt for credentials")]
        public int? PromptForCredentials { get; set; }

        /// <summary>
        /// RDG is KDC Proxy
        /// </summary>
        /// <remarks>
        /// This setting determines whether the Remote Desktop Gateway (RDG) is acting as a Key Distribution Center (KDC) proxy.
        /// </remarks>
        [DisplayName("RDG is KDC Proxy")]
        [Description("To Do")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "rdgiskdcproxy")]
        public int? RdgIsKdcProxy { get; set; }

        /// <summary>
        /// Redirect Drives
        /// </summary>
        /// <remarks>
        /// This setting determines whether drives on the client computer will be redirected and available in the remote session when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the selections for Drives under More on the Local Resources tab under Options in RDC.
        /// </remarks>
        [DisplayName("Redirect Drives")]
        [Description("This setting determines whether drives on the client computer will be redirected and available in the remote session when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the selections for Drives under More on the Local Resources tab under Options in RDC.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectdrives")]
        public int? RedirectDrives { get; set; }

        /// <summary>
        /// Redirect Printers
        /// </summary>
        /// <remarks>
        /// This setting determines whether printers on the client computer will be redirected and available in the remote session when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the selections for Printers under More on the Local Resources tab under Options in RDC.
        /// </remarks>
        [DisplayName("Redirect POS Devices")]
        [Description("This setting determines whether printers on the client computer will be redirected and available in the remote session when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the selections for Printers under More on the Local Resources tab under Options in RDC.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectposdevices")]
        public int? RedirectPosDevices { get; set; }

        /// <summary>
        /// Server Port
        /// </summary>
        /// <remarks>
        /// This setting determines which TCP port the Remote Desktop Protocol (RDP) will use when you connect to the remote computer by using Remote Desktop Connection (RDC). The default value is 0xD3D (3389).
        /// </remarks>
        [DisplayName("Server Port")]
        [Description("This setting determines which TCP port the Remote Desktop Protocol (RDP) will use when you connect to the remote computer by using Remote Desktop Connection (RDC). The default value is 0xD3D (3389). ")]
        [Range(0, 65535)]
        [DataMember(Name = "server port")]
        public int? ServerPort { get; set; }

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
        /// Shell Working Directory
        /// </summary>
        /// <remarks>
        /// This setting specifies the working directory on the remote computer where the Remote Desktop Connection (RDC) window will start.
        /// </remarks>
        [DisplayName("Sehll Working Directory")]
        [Description("This setting specifies the working directory on the remote computer where the Remote Desktop Connection (RDC) window will start.")]
        [DataMember(Name = "shell working directory")]
        public string ShellWorkingDirectory { get; set; }

        /// <summary>
        /// Span Monitors
        /// </summary>
        /// <remarks>
        /// This setting determines whether the remote session window will be spanned across multiple monitors when you connect to the remote computer by using Remote Desktop Connection (RDC).
        /// </remarks>
        [DisplayName("Span Monitors")]
        [Description("This setting determines whether the remote session window will be spanned across multiple monitors when you connect to the remote computer by using Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "span monitors")]
        public int? SpanMonitors { get; set; }

        /// <summary>
        /// Use Redirection Server Name
        /// </summary>
        /// <remarks>
        /// This setting determines whether the Remote Desktop Connection (RDC) client will use the redirection server name when connecting to the remote computer.
        /// </remarks>
        [DisplayName("Use Redirection Server Name")]
        [Description("This setting determines whether the Remote Desktop Connection (RDC) client will use the redirection server name when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "use redirection server name")]
        public int? UseRedirectionServerName { get; set; }

        /// <summary>
        /// Window Position
        /// </summary>
        /// <remarks>
        /// This setting specifies the position of the Remote Desktop Connection (RDC) window on the client computer. Represents a string form of the WINDOWSPOS structure. For more information about the WINDOWSPOS function, see https://msdn2.microsoft.com/en-us/library/ms632612.aspx. The default value is 0,3,0,0,800,600.
        /// </remarks>
        [DisplayName("Window Position")]
        [Description("This setting specifies the position of the Remote Desktop Connection (RDC) window on the client computer. Represents a string form of the WINDOWSPOS structure. For more information about the WINDOWSPOS function, see https://msdn2.microsoft.com/en-us/library/ms632612.aspx. The default value is 0,3,0,0,800,600.")]
        [DataMember(Name = "winposstr")]
        public string WindowPositionString { get; set; }

        /// <summary>
        /// Workspace Id
        /// </summary>
        /// <remarks>
        /// This setting defines the RemoteApp and Desktop ID associated with the RDP file that contains this setting.
        /// </remarks>
        [DisplayName("Workspace Id")]
        [Description("This setting defines the RemoteApp and Desktop ID associated with the RDP file that contains this setting.")]
        [DataMember(Name = "workspaceid")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets the window position.
        /// </summary>
        /// <returns>
        /// Returns the window position.
        /// </returns>
        public WindowPosition GetWindowPosition()
            => WindowPositionString != null ? new WindowPosition(WindowPositionString) : default;

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <remarks>
        /// If the window position is null, the default value is set to 0,3,0,0,800,600.
        /// </remarks>
        /// <param name="windowPosition">
        /// Position of the window.
        /// </param>
        public void SetWindowPosition(WindowPosition windowPosition)
            => WindowPositionString = windowPosition != null ? windowPosition.ToString() : "0,3,0,0,800,600";
    }
}
