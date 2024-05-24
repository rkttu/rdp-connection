using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace RdpConnection
{
    /// <summary>
    /// Represents the base properties for a remote desktop connection.
    /// </summary>
    /// <remarks>
    /// <see href="https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior"/>
    /// </remarks>
    [DataContract]
    public abstract class RemoteDesktopPropertiesBase
    {
        /// <summary>
        /// Microsoft Entra single sign-on
        /// </summary>
        /// <remarks>
        /// Determines whether the client will use Microsoft Entra ID to authenticate to the remote PC. In Azure Virtual Desktop, this provides a single sign-on experience. This property replaces the property targetisaadjoined.
        /// </remarks>
        [DisplayName("Microsoft Entra single sign-on")]
        [Description("Determines whether the client will use Microsoft Entra ID to authenticate to the remote PC. In Azure Virtual Desktop, this provides a single sign-on experience. This property replaces the property targetisaadjoined.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "enablerdsaadauth")]
        public int? EnableRdsAzureAdAuth { get; set; }

        /// <summary>
        /// Credential Security Support Provider
        /// </summary>
        /// <remarks>
        /// Determines whether the client will use the Credential Security Support Provider (CredSSP) for authentication if it's available.
        /// </remarks>
        [DisplayName("Credential Security Support Provider")]
        [Description("Determines whether the client will use the Credential Security Support Provider (CredSSP) for authentication if it's available.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "enablecredsspsupport")]
        public int? EnableCredSspSupport { get; set; }

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
        /// Reconnection
        /// </summary>
        /// <remarks>
        /// Determines whether the client will automatically try to reconnect to the remote computer if the connection is dropped, such as when there's a network connectivity interruption.
        /// </remarks>
        [DisplayName("Reconnection")]
        [Description("Determines whether the client will automatically try to reconnect to the remote computer if the connection is dropped, such as when there's a network connectivity interruption.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "autoreconnection enabled")]
        public int? AutoReconnectionEnabled { get; set; }

        /// <summary>
        /// Bandwidth auto detect
        /// </summary>
        /// <remarks>
        /// Determines whether or not to use automatic network bandwidth detection. Requires bandwidthautodetect to be set to 1.
        /// </remarks>
        [DisplayName("Bandwidth auto detect")]
        [Description("Determines whether or not to use automatic network bandwidth detection. Requires bandwidthautodetect to be set to 1.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "bandwidthautodetect")]
        public int? BandwidthAutoDetect { get; set; }

        /// <summary>
        /// Network auto detect
        /// </summary>
        /// <remarks>
        /// Determines whether automatic network type detection is enabled.
        /// </remarks>
        [DisplayName("Network auto detect")]
        [Description("Determines whether automatic network type detection is enabled.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "networkautodetect")]
        public int? NetworkAutoDetect { get; set; }

        /// <summary>
        /// Compression
        /// </summary>
        /// <remarks>
        /// Determines whether bulk compression is enabled when it's transmitted by RDP to the local computer.
        /// </remarks>
        [DisplayName("Compression")]
        [Description("Determines whether bulk compression is enabled when it's transmitted by RDP to the local computer.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "compression")]
        public int? Compression { get; set; }

        /// <summary>
        /// Video playback
        /// </summary>
        /// <remarks>
        /// Determines if the connection will use RDP-efficient multimedia streaming for video playback.
        /// </remarks>
        [DisplayName("Video playback")]
        [Description("Determines if the connection will use RDP-efficient multimedia streaming for video playback.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "videoplaybackmode")]
        public int? VideoPlaybackMode { get; set; }

        /// <summary>
        /// Microphone redirection
        /// </summary>
        /// <remarks>
        /// Indicates whether audio input redirection is enabled.
        /// </remarks>
        [DisplayName("Microphone redirection")]
        [Description("Indicates whether audio input redirection is enabled.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "audiocapturemode")]
        public int? AudioCaptureMode { get; set; }

        /// <summary>
        /// Redirect video encoding
        /// </summary>
        /// <remarks>
        /// Enables or disables encoding of redirected video.
        /// </remarks>
        [DisplayName("Redirect video encoding")]
        [Description("Enables or disables encoding of redirected video.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "encode redirected video capture")]
        public int? EncodedRedirectedVideoCapture { get; set; }

        /// <summary>
        /// Redirected video capture encoding quality
        /// </summary>
        /// <remarks>
        /// Controls the quality of encoded video.
        /// </remarks>
        [DisplayName("Redirected video capture encoding quality")]
        [Description("Controls the quality of encoded video.")]
        [RdpAllowedValues(0, 1, 2)]
        [DataMember(Name = "redirected video capture encoding quality")]
        public int? RedirectedVideoCaptureEncodingQuality { get; set; }

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
        /// Camera redirection
        /// </summary>
        /// <remarks>
        /// Configures which cameras to redirect. This setting uses a semicolon-delimited list of KSCATEGORY_VIDEO_CAMERA interfaces of cameras enabled for redirection.
        /// </remarks>
        [DisplayName("Camera redirection")]
        [Description("Configures which cameras to redirect. This setting uses a semicolon-delimited list of KSCATEGORY_VIDEO_CAMERA interfaces of cameras enabled for redirection.")]
        [DataMember(Name = "camerastoredirect")]
        public string CamerasToRedirect { get; set; }

        /// <summary>
        /// Media Transfer Protocol (MTP) and Picture Transfer Protocol (PTP) redirection
        /// </summary>
        /// <remarks>
        /// Determines which devices on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Media Transfer Protocol (MTP) and Picture Transfer Protocol (PTP) redirection")]
        [Description("Determines which devices on the local computer will be redirected and available in the remote session.")]
        [DataMember(Name = "devicestoredirect")]
        public string DevicesToRedirect { get; set; }

        /// <summary>
        /// Drive/storage redirection
        /// </summary>
        /// <remarks>
        /// Determines which disk drives on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Drive/storage redirection")]
        [Description("Determines which disk drives on the local computer will be redirected and available in the remote session.")]
        [DataMember(Name = "drivestoredirect")]
        public string DrivesToRedirect { get; set; }

        /// <summary>
        /// Windows key combinations
        /// </summary>
        /// <remarks>
        /// Determines when Windows key combinations (Windows, Alt+Tab) are applied to the remote session for desktop and RemoteApp connections.
        /// </remarks>
        [DisplayName("Windows key combinations")]
        [Description("Determines when Windows key combinations (Windows, Alt+Tab) are applied to the remote session for desktop and RemoteApp connections.")]
        [RdpAllowedValues(0, 1, 2, 3)]
        [DataMember(Name = "keyboardhook")]
        public int? KeyboardHook { get; set; }

        /// <summary>
        /// Clipboard redirection
        /// </summary>
        /// <remarks>
        /// Determines whether clipboard redirection is enabled.
        /// </remarks>
        [DisplayName("Clipboard redirection")]
        [Description("Determines whether clipboard redirection is enabled.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectclipboard")]
        public int? RedirectClipboard { get; set; }

        /// <summary>
        /// COM ports redirection
        /// </summary>
        /// <remarks>
        /// Determines whether COM (serial) ports on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("COM ports redirection")]
        [Description("Determines whether COM (serial) ports on the local computer will be redirected and available in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectcomports")]
        public int? RedirectCOMPorts { get; set; }

        /// <summary>
        /// Location service redirection
        /// </summary>
        /// <remarks>
        /// Determines whether the location of the local device will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Location service redirection")]
        [Description("Determines whether the location of the local device will be redirected and available in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectlocation")]
        public int? RedirectLocation { get; set; }

        /// <summary>
        /// Printers redirection
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
        /// Smart card redirection
        /// </summary>
        /// <remarks>
        /// Determines whether smart card devices on the local computer will be redirected and available in the remote session.
        /// </remarks>
        [DisplayName("Smart card redirection")]
        [Description("Determines whether smart card devices on the local computer will be redirected and available in the remote session.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectsmartcards")]
        public int? RedirectSmartCards { get; set; }

        /// <summary>
        /// WebAuthn redirection
        /// </summary>
        /// <remarks>
        /// Determines whether WebAuthn requests on the remote computer will be redirected to the local computer allowing the use of local authenticators (such as Windows Hello for Business and security key).
        /// </remarks>
        [DisplayName("WebAuthn redirection")]
        [Description("Determines whether WebAuthn requests on the remote computer will be redirected to the local computer allowing the use of local authenticators (such as Windows Hello for Business and security key).")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "redirectwebauthn")]
        public int? RedirectWebAuthn { get; set; }

        /// <summary>
        /// USB device redirection
        /// </summary>
        /// <remarks>
        /// Determines which supported RemoteFX USB devices on the client computer will be redirected and available in the remote session when you connect to a remote session that supports RemoteFX USB redirection.
        /// </remarks>
        [DisplayName("USB device redirection")]
        [Description("Determines which supported RemoteFX USB devices on the client computer will be redirected and available in the remote session when you connect to a remote session that supports RemoteFX USB redirection.")]
        [DataMember(Name = "usbdevicestoredirect")]
        public string UsbDevicesToRedirect { get; set; }

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

        /// <summary>
        /// Selected monitors
        /// </summary>
        /// <remarks>
        /// Specifies which local displays to use from the remote session. The selected displays must be contiguous. Requires use multimon to be set to 1. Only available on the Windows Inbox(MSTSC) and Windows Desktop(MSRDC) clients.
        /// </remarks>
        [DisplayName("Selected monitors")]
        [Description("Specifies which local displays to use from the remote session. The selected displays must be contiguous. Requires use multimon to be set to 1. Only available on the Windows Inbox(MSTSC) and Windows Desktop(MSRDC) clients.")]
        [DataMember(Name = "selectedmonitors")]
        public string SelectedMonitors { get; set; }

        /// <summary>
        /// Maximize to current displays
        /// </summary>
        /// <remarks>
        /// Determines which display the remote session goes full screen on when maximizing. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.
        /// </remarks>
        [DisplayName("Maximize to current displays")]
        [Description("Determines which display the remote session goes full screen on when maximizing. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "maximizetocurrentdisplays")]
        public int? MaximizeToCurrentDisplays { get; set; }

        /// <summary>
        /// Multi to single display switch
        /// </summary>
        /// <remarks>
        /// Determines whether a multi display remote session automatically switches to single display when exiting full screen. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.
        /// </remarks>
        [DisplayName("Multi to single display switch")]
        [Description("Determines whether a multi display remote session automatically switches to single display when exiting full screen. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "singlemoninwindowedmode")]
        public int? SingleMonitorInWindowedMode { get; set; }

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
        /// Smart sizing
        /// </summary>
        /// <remarks>
        /// Determines whether or not the local computer scales the content of the remote session to fit the window size.
        /// </remarks>
        [DisplayName("Smart sizing")]
        [Description("Determines whether or not the local computer scales the content of the remote session to fit the window size.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "smart sizing")]
        public int? SmartSizing { get; set; }

        /// <summary>
        /// Dynamic resolution
        /// </summary>
        /// <remarks>
        /// Determines whether the resolution of the remote session is automatically updated when the local window is resized.
        /// </remarks>
        [DisplayName("Dynamic resolution")]
        [Description("Determines whether the resolution of the remote session is automatically updated when the local window is resized.")]
        [RdpAllowedValues(0, 1)]
        [DataMember(Name = "dynamic resolution")]
        public int? DynamicResolution { get; set; }

        /// <summary>
        /// Desktop size
        /// </summary>
        /// <remarks>
        /// Specifies the dimensions of the remote session desktop from a set of predefined options. This setting is overridden if desktopheight and desktopwidth are specified.
        /// </remarks>
        [DisplayName("Desktop size")]
        [Description("Specifies the dimensions of the remote session desktop from a set of predefined options. This setting is overridden if desktopheight and desktopwidth are specified.")]
        [RdpAllowedValues(0, 1, 2, 3, 4)]
        [DataMember(Name = "desktop size id")]
        public int? DesktopSizeId { get; set; }

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
        /// Desktop scale factor
        /// </summary>
        /// <remarks>
        /// Specifies the scale factor of the remote session to make the content appear larger.
        /// </remarks>
        [DisplayName("Desktop scale factor")]
        [Description("Specifies the scale factor of the remote session to make the content appear larger.")]
        [RdpAllowedValues(100, 125, 150, 175, 200, 250, 300, 400, 500)]
        [DataMember(Name = "desktopscalefactor")]
        public int? DesktopScaleFactor { get; set; }

        /// <summary>
        /// Get the cameras to redirect.
        /// </summary>
        /// <returns>
        /// A string collection of cameras to redirect. Semi-colon delimited.
        /// </returns>
        public IEnumerable<string> GetCamerasToRedirect()
            => CamerasToRedirect?.Split(Constants.SemicolonSeparator, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

        /// <summary>
        /// Set the cameras to redirect.
        /// </summary>
        /// <param name="list">
        /// A collection of cameras to redirect. Semi-colon delimited.
        /// </param>
        public void SetCamerasToRedirect(IEnumerable<string> list)
            => CamerasToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

        /// <summary>
        /// Check if all cameras are to be redirected. if <see cref="CamerasToRedirect"/> is set to "*", this property will return true.
        /// </summary>
        [IgnoreDataMember]
        public bool RedirectAllCameras
            => string.Equals("*", CamerasToRedirect, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Set all cameras to be redirected.
        /// </summary>
        public void SetRedirectAllCameras()
            => CamerasToRedirect = "*";

        /// <summary>
        /// Get the devices to redirect.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDevicesToRedirect()
            => DevicesToRedirect?.Split(Constants.SemicolonSeparator, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

        /// <summary>
        /// Set the devices to redirect.
        /// </summary>
        /// <param name="list">
        /// A collection of cameras to redirect. Semi-colon delimited.
        /// </param>
        public void SetDevicesToRedirect(IEnumerable<string> list)
            => DevicesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

        /// <summary>
        /// Check if all devices are to be redirected. if <see cref="DevicesToRedirect"/> is set to "*", this property will return true.
        /// </summary>
        [IgnoreDataMember]
        public bool RedirectAllDevices
            => string.Equals("*", DevicesToRedirect, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Set all devices to be redirected.
        /// </summary>
        public void SetRedirectAllDevices()
            => DevicesToRedirect = "*";

        /// <summary>
        /// Check if dynamic devices are to be redirected. if <see cref="DevicesToRedirect"/> is set to "DynamicDevices", this property will return true.
        /// </summary>
        [IgnoreDataMember]
        public bool RedirectDynamicDevices
            => string.Equals("DynamicDevices", DevicesToRedirect, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Set dynamic devices to be redirected.
        /// </summary>
        public void SetRedirectDynamicDevices()
            => DevicesToRedirect = "DynamicDevices";

        /// <summary>
        /// Get the drives to redirect.
        /// </summary>
        /// <returns>
        /// A string collection of drives to redirect. Semi-colon delimited.
        /// </returns>
        public IEnumerable<string> GetDrivesToRedirect()
            => DrivesToRedirect?.Split(Constants.SemicolonSeparator, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

        /// <summary>
        /// Set the drives to redirect.
        /// </summary>
        /// <param name="list">
        /// A collection of drives to redirect. Semi-colon delimited.
        /// </param>
        public void SetDrivesToRedirect(IEnumerable<string> list)
            => DrivesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

        /// <summary>
        /// Check if all drives are to be redirected. if <see cref="DrivesToRedirect"/> is set to "*", this property will return true.
        /// </summary>
        [IgnoreDataMember]
        public bool RedirectAllDrives
            => string.Equals("*", DrivesToRedirect, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Set all drives to be redirected.
        /// </summary>
        public void SetRedirectAllDrives()
            => DrivesToRedirect = "*";

        /// <summary>
        /// Check if dynamic drives are to be redirected. if <see cref="DrivesToRedirect"/> is set to "DynamicDrives", this property will return true.`
        /// </summary>
        [IgnoreDataMember]
        public bool RedirectDynamicDrives
            => string.Equals("DynamicDrives", DrivesToRedirect, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Set dynamic drives to be redirected.
        /// </summary>
        public void SetRedirectDynamicDrives()
            => DrivesToRedirect = "DynamicDrive";

        /// <summary>
        /// Get the selected monitors.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetUsbDevicesToRedirect()
            => UsbDevicesToRedirect?.Split(Constants.SemicolonSeparator, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

        /// <summary>
        /// Set the USB devices to redirect.
        /// </summary>
        /// <param name="list"></param>
        public void SetUsbDevicesToRedirect(IEnumerable<string> list)
            => UsbDevicesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

        /// <summary>
        /// Set all USB devices to be redirected.
        /// </summary>
        /// <param name="list">
        /// A collection of USB devices to redirect. Semi-colon delimited.
        /// </param>
        public void SetUsbDevicesToRedirect(IEnumerable<DeviceSetupClassGuids> list)
            => UsbDevicesToRedirect = string.Join(";", list.Select(x => x.ClassGuid.ToString("B")));

        /// <summary>
        /// Get the selected monitors.
        /// </summary>
        /// <returns>
        /// A string collection of selected monitors. comma delimited.
        /// </returns>
        public IEnumerable<string> GetSelectedMonitors()
            => SelectedMonitors?.Split(Constants.CommaSeparator, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

        /// <summary>
        /// Set the selected monitors.
        /// </summary>
        /// <param name="list">
        /// A collection of selected monitors. comma delimited.
        /// </param>
        public void SetSelectedMonitors(IEnumerable<string> list)
            => SelectedMonitors = list != null && list.Count() > 0 ? string.Join(",", list) : default;
    }
}
