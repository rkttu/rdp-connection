using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;

namespace RdpConnection;

// https://learn.microsoft.com/en-us/windows-server/remote/remote-desktop-services/clients/rdp-files#session-behavior
[DataContract]
public abstract class RemoteDesktopServicePropertiesBase
{
    [DisplayName("Microsoft Entra single sign-on")]
    [Description("Determines whether the client will use Microsoft Entra ID to authenticate to the remote PC. In Azure Virtual Desktop, this provides a single sign-on experience. This property replaces the property targetisaadjoined.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "enablerdsaadauth")]
    public int? EnableRdsAzureAdAuth { get; set; }

    [DisplayName("Credential Security Support Provider")]
    [Description("Determines whether the client will use the Credential Security Support Provider (CredSSP) for authentication if it's available.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "enablecredsspsupport")]
    public int? EnableCredSspSupport { get; set; }

    [DisplayName("Alternate shell")]
    [Description("Specifies a program to be started automatically in the remote session as the shell instead of explorer.")]
    [DataMember(Name = "alternate shell")]
    public string? AlternateShell { get; set; }

    [DisplayName("Reconnection")]
    [Description("Determines whether the client will automatically try to reconnect to the remote computer if the connection is dropped, such as when there's a network connectivity interruption.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "autoreconnection enabled")]
    public int? AutoReconnectionEnabled { get; set; }

    [DisplayName("Bandwidth auto detect")]
    [Description("Determines whether or not to use automatic network bandwidth detection. Requires bandwidthautodetect to be set to 1.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "bandwidthautodetect")]
    public int? BandwidthAutoDetect { get; set; }

    [DisplayName("Network auto detect")]
    [Description("Determines whether automatic network type detection is enabled.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "networkautodetect")]
    public int? NetworkAutoDetect { get; set; }

    [DisplayName("Compression")]
    [Description("Determines whether bulk compression is enabled when it's transmitted by RDP to the local computer.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "compression")]
    public int? Compression { get; set; }

    [DisplayName("Video playback")]
    [Description("Determines if the connection will use RDP-efficient multimedia streaming for video playback.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "videoplaybackmode")]
    public int? VideoPlaybackMode { get; set; }

    [DisplayName("Microphone redirection")]
    [Description("Indicates whether audio input redirection is enabled.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "audiocapturemode")]
    public int? AudioCaptureMode { get; set; }

    [DisplayName("Redirect video encoding")]
    [Description("Enables or disables encoding of redirected video.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "encode redirected video capture")]
    public int? EncodedRedirectedVideoCapture { get; set; }

    [DisplayName("Redirect video encoding")]
    [Description("Controls the quality of encoded video.")]
    [AllowedValues(0, 1, 2)]
    [DataMember(Name = "redirected video capture encoding quality")]
    public int? RedirectedVideoCaptureEncodingQuality { get; set; }

    [DisplayName("Audio output location")]
    [Description("Determines whether the local or remote machine plays audio.")]
    [AllowedValues(0, 1, 2)]
    [DataMember(Name = "audiomode")]
    public int? AudioMode { get; set; }

    [DisplayName("Camera redirection")]
    [Description("Configures which cameras to redirect. This setting uses a semicolon-delimited list of KSCATEGORY_VIDEO_CAMERA interfaces of cameras enabled for redirection.")]
    [DataMember(Name = "camerastoredirect")]
    public string? CamerasToRedirect { get; set; }

    [DisplayName("Media Transfer Protocol (MTP) and Picture Transfer Protocol (PTP) redirection")]
    [Description("Determines which devices on the local computer will be redirected and available in the remote session.")]
    [DataMember(Name = "devicestoredirect")]
    public string? DevicesToRedirect { get; set; }

    [DisplayName("Drive/storage redirection")]
    [Description("Determines which disk drives on the local computer will be redirected and available in the remote session.")]
    [DataMember(Name = "drivestoredirect")]
    public string? DrivesToRedirect { get; set; }

    [DisplayName("Windows key combinations")]
    [Description("Determines when Windows key combinations (Windows, Alt+Tab) are applied to the remote session for desktop and RemoteApp connections.")]
    [AllowedValues(0, 1, 2, 3)]
    [DataMember(Name = "keyboardhook")]
    public int? KeyboardHook { get; set; }

    [DisplayName("Clipboard redirection")]
    [Description("Determines whether clipboard redirection is enabled.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectclipboard")]
    public int? RedirectClipboard { get; set; }

    [DisplayName("COM ports redirection")]
    [Description("Determines whether COM (serial) ports on the local computer will be redirected and available in the remote session.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectcomports")]
    public int? RedirectCOMPorts { get; set; }

    [DisplayName("Location service redirection")]
    [Description("Determines whether the location of the local device will be redirected and available in the remote session.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectlocation")]
    public int? RedirectLocation { get; set; }

    [DisplayName("Printer redirection")]
    [Description("Determines whether printers configured on the local computer will be redirected and available in the remote session.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectprinters")]
    public int? RedirectPrinters { get; set; }

    [DisplayName("Smart card redirection")]
    [Description("Determines whether smart card devices on the local computer will be redirected and available in the remote session.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectsmartcards")]
    public int? RedirectSmartCards { get; set; }

    [DisplayName("WebAuthn redirection")]
    [Description("Determines whether WebAuthn requests on the remote computer will be redirected to the local computer allowing the use of local authenticators (such as Windows Hello for Business and security key).")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "redirectwebauthn")]
    public int? RedirectWebAuthn { get; set; }

    [DisplayName("USB device redirection")]
    [Description("Determines which supported RemoteFX USB devices on the client computer will be redirected and available in the remote session when you connect to a remote session that supports RemoteFX USB redirection.")]
    [DataMember(Name = "usbdevicestoredirect")]
    public string? UsbDevicesToRedirect { get; set; }

    [DisplayName("Multiple displays")]
    [Description("Determines whether the remote session will use one or multiple displays from the local computer.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "use multimon")]
    public int? UseMultipleMonitors { get; set; }

    [DisplayName("Selected monitors")]
    [Description("Specifies which local displays to use from the remote session. The selected displays must be contiguous. Requires use multimon to be set to 1. Only available on the Windows Inbox(MSTSC) and Windows Desktop(MSRDC) clients.")]
    [DataMember(Name = "selectedmonitors")]
    public string? SelectedMonitors { get; set; }

    [DisplayName("Maximize to current displays")]
    [Description("Determines which display the remote session goes full screen on when maximizing. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "maximizetocurrentdisplays")]
    public int? MaximizeToCurrentDisplays { get; set; }

    [DisplayName("Multi to single display switch")]
    [Description("Determines whether a multi display remote session automatically switches to single display when exiting full screen. Requires use multimon to be set to 1. Only available on the Windows Desktop(MSRDC) client.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "singlemoninwindowedmode")]
    public int? SingleMonitorInWindowedMode { get; set; }

    [DisplayName("Screen mode")]
    [Description("Determines whether the remote session window appears full screen when you launch the connection.")]
    [AllowedValues(1, 2)]
    [DataMember(Name = "screen mode id")]
    public int? ScreenModeId { get; set; }

    [DisplayName("Smart sizing")]
    [Description("Determines whether or not the local computer scales the content of the remote session to fit the window size.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "smart sizing")]
    public int? SmartSizing { get; set; }

    [DisplayName("Dynamic resolution")]
    [Description("Determines whether the resolution of the remote session is automatically updated when the local window is resized.")]
    [AllowedValues(0, 1)]
    [DataMember(Name = "dynamic resolution")]
    public int? DynamicResolution { get; set; }

    [DisplayName("Desktop size")]
    [Description("Specifies the dimensions of the remote session desktop from a set of predefined options. This setting is overridden if desktopheight and desktopwidth are specified.")]
    [AllowedValues(null, 0, 1, 2, 3, 4)]
    [DataMember(Name = "desktop size id")]
    public int? DesktopSizeId { get; set; }

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

    [DisplayName("Desktop scale factor")]
    [Description("Specifies the scale factor of the remote session to make the content appear larger.")]
    [AllowedValues(null, 100, 125, 150, 175, 200, 250, 300, 400, 500)]
    [DataMember(Name = "desktopscalefactor")]
    public int? DesktopScaleFactor { get; set; }

    public IEnumerable<string> GetCamerasToRedirect()
        => CamerasToRedirect?.Split(';', StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

    public void SetCamerasToRedirect(IEnumerable<string> list)
        => CamerasToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

    [IgnoreDataMember]
    public bool RedirectAllCameras
        => string.Equals("*", CamerasToRedirect, StringComparison.OrdinalIgnoreCase);

    public void SetRedirectAllCameras()
        => CamerasToRedirect = "*";

    public IEnumerable<string> GetDevicesToRedirect()
        => DevicesToRedirect?.Split(';', StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

    public void SetDevicesToRedirect(IEnumerable<string> list)
        => DevicesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

    [IgnoreDataMember]
    public bool RedirectAllDevices
        => string.Equals("*", DevicesToRedirect, StringComparison.OrdinalIgnoreCase);

    public void SetRedirectAllDevices()
        => DevicesToRedirect = "*";

    [IgnoreDataMember]
    public bool RedirectDynamicDevices
        => string.Equals("DynamicDevices", DevicesToRedirect, StringComparison.OrdinalIgnoreCase);

    public void SetRedirectDynamicDevices()
        => DevicesToRedirect = "DynamicDevices";

    public IEnumerable<string> GetDrivesToRedirect()
        => DrivesToRedirect?.Split(';', StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

    public void SetDrivesToRedirect(IEnumerable<string> list)
        => DrivesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

    [IgnoreDataMember]
    public bool RedirectAllDrives
        => string.Equals("*", DrivesToRedirect, StringComparison.OrdinalIgnoreCase);

    public void SetRedirectAllDrives()
        => DrivesToRedirect = "*";

    [IgnoreDataMember]
    public bool RedirectDynamicDrives
        => string.Equals("DynamicDrives", DrivesToRedirect, StringComparison.OrdinalIgnoreCase);

    public void SetRedirectDynamicDrives()
        => DrivesToRedirect = "DynamicDrive";

    public IEnumerable<string> GetUsbDevicesToRedirect()
        => UsbDevicesToRedirect?.Split(';', StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

    public void SetUsbDevicesToRedirect(IEnumerable<string> list)
        => UsbDevicesToRedirect = list != null && list.Count() > 0 ? string.Join(";", list) : default;

    public void SetUsbDevicesToRedirect(IEnumerable<DeviceSetupClassGuids> list)
        => UsbDevicesToRedirect = string.Join(";", list.Select(x => x.ClassGuid.ToString("B")));

    public IEnumerable<string> GetSelectedMonitors()
        => SelectedMonitors?.Split(',', StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();

    public void SetSelectedMonitors(IEnumerable<string> list)
        => SelectedMonitors = list != null && list.Count() > 0 ? string.Join(",", list) : default;
}
