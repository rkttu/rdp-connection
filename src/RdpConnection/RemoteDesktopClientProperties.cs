using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-r2-and-2008/ff393699(v=ws.10)
    [DataContract]
    public class RemoteDesktopClientProperties : RemoteDesktopServiceProperties
    {
        [DisplayName("Administrative session")]
        [Description("This setting configures the client computer to connect to the administrative session of the remote computer. This setting is the same as the /admin parameter used with mstsc.exe.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "administrative session")]
        public int? AdministrativeSession { get; set; }

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

        [DisplayName("Audio Quality Mode")]
        [Description("This setting determines the audio playback quality on the local computer.")]
        [RdpAllowedValues(0, 1, 2)]
        [DataMember(Name = "audioqualitymode")]
        public int? AudioQualityMode { get; set; }

        [DisplayName("Auto reconnect max retries")]
        [Description("This setting determines the maximum number of times the client computer will automatically try to reconnect to the remote computer if the connection is dropped, for example, when there is an interruption of network connectivity.")]
        [Range(0, Int32.MaxValue)]
        [DataMember(Name = "autoreconnect max retries")]
        public int? AutoReconnectMaxRetries { get; set; }

        [DisplayName("Bitmap Cache Persist Enabled")]
        [Description("This setting determines whether bitmaps are cached on the local computer. Bitmap caching can improve the performance of your remote session by storing frequently used images on the local computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "bitmapcachepersistenable")]
        public int? BitmapCachePersistEnable { get; set; }

        [DisplayName("Connection Type")]
        [Description("This setting configures the client computer’s connection speed. This setting corresponds to the selections for Choose your connection speed to optimize performance on the Experience tab under Options in Remote Desktop Connection.")]
        [RdpAllowedValues(1, 2, 3, 4, 5, 6, 7)]
        [DataMember(Name = "connection type")]
        public int? ConnectionType { get; set; }

        [DisplayName("Disable Ctrl + Alt + Delete")]
        [Description("This setting determines whether the CTRL+ALT+DELETE security attention sequence is required to enter credentials after you are connected to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable ctrl+alt+del")]
        public int? DisableCtrlAltDel { get; set; }

        [DisplayName("Disable Printer Redirection")]
        [Description("This setting determines whether Easy Print printer redirection is enabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableprinterredirection")]
        public int? DisablePrinterRedirection { get; set; }

        [DisplayName("Disable Clipboard Redirection")]
        [Description("This setting determines whether Clipboard redirection is enabled when connecting to the remote computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disableclipboardredirection")]
        public int? DisableClipboardRedirection { get; set; }

        [DisplayName("Disable Cursor Settings")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable cursor setting")]
        public int? DisableCursorSettings { get; set; }

        [DisplayName("Disable Wallpaper")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "disable wallpaper")]
        public int? DisableWallpaper { get; set; }

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

        [DisplayName("Display Connection Bar")]
        [Description("This setting determines whether the connection bar appears when you are in full screen mode when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the Display the connection bar when I use the full screen check box on the Display tab under Options in RDC.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "displayconnectionbar")]
        public int? DisplayConnectionBar { get; set; }

        [DisplayName("Enable Workspace Reconnect")]
        [Description("To Do")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "enableworkspacereconnect")]
        public int? EnableWorkspaceReconnect { get; set; }

        [DisplayName("Gateway Brokering Type")]
        [Description("To Do")]
        [DataMember(Name = "gatewaybrokeringtype")]
        public int? GatewayBrokeringType { get; set; }

        [DisplayName("KDC proxy name")]
        [Description("Specifies the fully qualified domain name of a KDC proxy.")]
        [DataMember(Name = "kdcproxyname")]
        public string KdcProxyName { get; set; }

        [DisplayName("Load balance info")]
        [Description("This setting specifies the provider name, endpoint type, and an endpoint. Load-balancing information used to choose the best server for the client computer. For more information about LoadBalanceInfo, see (https://msdn.microsoft.com/en-us/library/aa381177(VS.85).aspx).")]
        [DataMember(Name = "loadbalanceinfo")]
        public string LoadBalanceInfo { get; set; }

        [DisplayName("Negotiate Security Layer")]
        [Description("This setting determines whether or not RDP negotiates the security layer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "negotiate security layer")]
        public int? NegotiateSecurityLayer { get; set; }

        [DisplayName("Pin Connection Bar")]
        [Description("This setting determines whether or not the connection bar should be pinned to the top of the remote session upon connection.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "pinconnectionbar")]
        public int? PinConnectionBar { get; set; }

        [DisplayName("Prompt for credentials")]
        [Description("This setting determines whether or not Remote Desktop Connection (RDC) prompts for credentials when connecting to a server that does not support server authentication.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "prompt for credentials")]
        public int? PromptForCredentials { get; set; }

        [DisplayName("RDG is KDC Proxy")]
        [Description("To Do")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "rdgiskdcproxy")]
        public int? RdgIsKdcProxy { get; set; }

        [DisplayName("Redirect Drives")]
        [Description("This setting determines whether drives on the client computer will be redirected and available in the remote session when you connect to a remote computer by using Remote Desktop Connection (RDC). This setting corresponds to the selections for Drives under More on the Local Resources tab under Options in RDC.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectdrives")]
        public int? RedirectDrives { get; set; }

        [DisplayName("Redirect POS Devices")]
        [Description("To Do")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectposdevices")]
        public int? RedirectPosDevices { get; set; }

        [DisplayName("Server Port")]
        [Description("This setting determines which TCP port the Remote Desktop Protocol (RDP) will use when you connect to the remote computer by using Remote Desktop Connection (RDC). The default value is 0xD3D (3389). ")]
        [Range(0, 65535)]
        [DataMember(Name = "server port")]
        public int? ServerPort { get; set; }

        [DisplayName("Session Bpp")]
        [Description("This setting determines the color depth on the remote computer when you connect by using Remote Desktop Connection (RDC). This setting corresponds to the selection in the Colors drop - down list on the Display tab under Options in RDC.")]
        [RdpAllowedValues(8, 15, 16, 24, 32)]
        [DataMember(Name = "session bpp")]
        public int? SessionBpp { get; set; }

        [DisplayName("Sehll Working Directory")]
        [Description("To Do: Need to add a description for a property")]
        [DataMember(Name = "shell working directory")]
        public string ShellWorkingDirectory { get; set; }

        [DisplayName("Span Monitors")]
        [Description("This setting determines whether the remote session window will be spanned across multiple monitors when you connect to the remote computer by using Remote Desktop Connection (RDC).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "span monitors")]
        public int? SpanMonitors { get; set; }

        [DisplayName("Use Redirection Server Name")]
        [Description("To Do: Need to add a description for a property")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "use redirection server name")]
        public int? UseRedirectionServerName { get; set; }

        [DisplayName("Window Position")]
        [Description("This setting specifies the position of the Remote Desktop Connection (RDC) window on the client computer. Represents a string form of the WINDOWSPOS structure. For more information about the WINDOWSPOS function, see https://msdn2.microsoft.com/en-us/library/ms632612.aspx. The default value is 0,3,0,0,800,600.")]
        [DataMember(Name = "winposstr")]
        public string WindowPositionString { get; set; }

        [DisplayName("Workspace Id")]
        [Description("This setting defines the RemoteApp and Desktop ID associated with the RDP file that contains this setting.")]
        [DataMember(Name = "workspaceid")]
        public string WorkspaceId { get; set; }

        public WindowPosition GetWindowPosition()
            => WindowPositionString != null ? new WindowPosition(WindowPositionString) : default;

        public void SetWindowPosition(WindowPosition windowPosition)
            => WindowPositionString = windowPosition != null ? windowPosition.ToString() : "0,3,0,0,800,600";
    }
}
