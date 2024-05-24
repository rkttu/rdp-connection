using System;

namespace RdpConnection
{
    // https://learn.microsoft.com/en-us/windows-hardware/drivers/install/system-defined-device-setup-classes-available-to-vendors

    /// <summary>
    /// Device setup class GUIDs are used to install devices. These GUIDs are defined by Microsoft for use in INF files.
    /// </summary>
    public sealed class DeviceSetupClassGuids
    {
        private DeviceSetupClassGuids(
            string displayName,
            string className,
            Guid classGuid,
            string description = default)
        {
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            ClassName = className ?? throw new ArgumentNullException(nameof(className));
            ClassGuid = classGuid;
            Description = description ?? string.Empty;
        }

        /// <summary>
        /// Display name of the device setup class.
        /// </summary>
        public string DisplayName { get; } = string.Empty;

        /// <summary>
        /// Class name of the device setup class.
        /// </summary>
        public string ClassName { get; } = string.Empty;

        /// <summary>
        /// Class GUID of the device setup class.
        /// </summary>
        public Guid ClassGuid { get; } = default(Guid);

        /// <summary>
        /// Description of the device setup class.
        /// </summary>
        public string Description { get; } = string.Empty;

        /// <summary>
        /// The string representation of the device setup class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => ClassGuid.ToString();

        /// <summary>
        /// Audio Processing Objects (APOs)
        /// </summary>
        /// <remarks>
        /// This class includes Audio processing objects (APOs). For more info, see Windows Audio Processing Objects.
        /// </remarks>
        public static readonly DeviceSetupClassGuids AudioProcessingObject = new DeviceSetupClassGuids(
            "Audio Processing Objects (APOs)",
            "AudioProcessingObject",
            new Guid("{5989fce8-9cd0-467d-8a6a-5419e31529d4}"),
            "This class includes Audio processing objects (APOs). For more info, see Windows Audio Processing Objects.");

        /// <summary>
        /// Battery Devices
        /// </summary>
        /// <remarks>
        /// This class includes battery devices and UPS devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Battery = new DeviceSetupClassGuids(
            "Battery Devices",
            "Battery",
            new Guid("{72631e54-78a4-11d0-bcf7-00aa00b7b32a}"),
            "This class includes battery devices and UPS devices.");

        /// <summary>
        /// Biometric Device
        /// </summary>
        /// <remarks>
        /// (Windows Server 2003 and later versions of Windows) This class includes all biometric-based personal identification devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Biometric = new DeviceSetupClassGuids(
            "Biometric Device",
            "Biometric",
            new Guid("{53D29EF7-377C-4D14-864B-EB3A85769359}"),
            "(Windows Server 2003 and later versions of Windows) This class includes all biometric-based personal identification devices.");

        /// <summary>
        /// Bluetooth Devices
        /// </summary>
        /// <remarks>
        /// (Windows XP SP1 and later versions of Windows) This class includes all Bluetooth devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Bluetooth = new DeviceSetupClassGuids(
            "Bluetooth Devices",
            "Bluetooth",
            new Guid("{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}"),
            "(Windows XP SP1 and later versions of Windows) This class includes all Bluetooth devices.");

        /// <summary>
        /// Camera Device
        /// </summary>
        /// <remarks>
        /// (Windows 10 version 1709 and later versions of Windows) This class includes universal camera drivers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Camera = new DeviceSetupClassGuids(
            "Camera Device",
            "Camera",
            new Guid("{ca3e7ab9-b4c3-4ae6-8251-579ef933890f}"),
            "(Windows 10 version 1709 and later versions of Windows) This class includes universal camera drivers.");

        /// <summary>
        /// CD-ROM Drives
        /// </summary>
        /// <remarks>
        /// This class includes CD-ROM drives, including SCSI CD-ROM drives. By default, the system's CD-ROM class installer also installs a system-supplied CD audio driver and CD-ROM changer driver as Plug and Play filters.
        /// </remarks>
        public static readonly DeviceSetupClassGuids CDROM = new DeviceSetupClassGuids(
            "CD-ROM Drives",
            "CDROM",
            new Guid("{4d36e965-e325-11ce-bfc1-08002be10318}"),
            "This class includes CD-ROM drives, including SCSI CD-ROM drives. By default, the system's CD-ROM class installer also installs a system-supplied CD audio driver and CD-ROM changer driver as Plug and Play filters.");

        /// <summary>
        /// Disk Drives
        /// </summary>
        /// <remarks>
        /// This class includes hard disk drives. See also the HDC and SCSIAdapter classes.
        /// </remarks>
        public static readonly DeviceSetupClassGuids DiskDrive = new DeviceSetupClassGuids(
            "Disk Drives",
            "DiskDrive",
            new Guid("{4d36e967-e325-11ce-bfc1-08002be10318}"),
            "This class includes hard disk drives. See also the HDC and SCSIAdapter classes.");

        /// <summary>
        /// Display Adapters
        /// </summary>
        /// <remarks>
        /// This class includes video adapters. Drivers for this class include display drivers and video miniport drivers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Display = new DeviceSetupClassGuids(
            "Display Adapters",
            "Display",
            new Guid("{4d36e968-e325-11ce-bfc1-08002be10318}"),
            "This class includes video adapters. Drivers for this class include display drivers and video miniport drivers.");

        /// <summary>
        /// Extension
        /// </summary>
        /// <remarks>
        /// (Windows 10 and later versions of Windows) This class includes all devices requiring customizations. For more details, see Using an Extension INF File.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Extension = new DeviceSetupClassGuids(
            "Extension INF",
            "Extension",
            new Guid("{e2f84ce7-8efa-411c-aa69-97454ca4cb57}"),
            "(Windows 10 and later versions of Windows) This class includes all devices requiring customizations. For more details, see Using an Extension INF File.");

        /// <summary>
        /// Floppy Disk Controllers
        /// </summary>
        /// <remarks>
        /// This class includes floppy disk drive controllers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids FDC = new DeviceSetupClassGuids(
            "Floppy Disk Controllers",
            "FDC",
            new Guid("{4d36e969-e325-11ce-bfc1-08002be10318}"),
            "This class includes floppy disk drive controllers.");

        /// <summary>
        /// Floppy Disk Drives
        /// </summary>
        /// <remarks>
        /// This class includes floppy disk drives.
        /// </remarks>
        public static readonly DeviceSetupClassGuids FloppyDisk = new DeviceSetupClassGuids(
            "Floppy Disk Drives",
            "FloppyDisk",
            new Guid("{4d36e980-e325-11ce-bfc1-08002be10318}"),
            "This class includes floppy disk drives.");

        /// <summary>
        /// Hard Disk Controllers
        /// </summary>
        /// <remarks>
        /// This class includes hard disk controllers, including ATA/ATAPI controllers but not SCSI and RAID disk controllers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids HDC = new DeviceSetupClassGuids(
            "Hard Disk Controllers",
            "HDC",
            new Guid("{4d36e96a-e325-11ce-bfc1-08002be10318}"),
            "This class includes hard disk controllers, including ATA/ATAPI controllers but not SCSI and RAID disk controllers.");

        /// <summary>
        /// Human Interface Devices (HID)
        /// </summary>
        /// <remarks>
        /// This class includes interactive input devices that are operated by the system-supplied HID class driver. This includes USB devices that comply with the USB HID Standard and non-USB devices that use a HID minidriver. For more information, see HIDClass Device Setup Class. (See also the Keyboard or Mouse classes later in this list.)
        /// </remarks>
        public static readonly DeviceSetupClassGuids HIDClass = new DeviceSetupClassGuids(
            "Human Interface Devices (HID)",
            "HIDClass",
            new Guid("{745a17a0-74d3-11d0-b6fe-00a0c90f57da}"),
            "This class includes interactive input devices that are operated by the system-supplied HID class driver. This includes USB devices that comply with the USB HID Standard and non-USB devices that use a HID minidriver. For more information, see HIDClass Device Setup Class. (See also the Keyboard or Mouse classes later in this list.)");

        /// <summary>
        /// IEEE 1284.4 Devices
        /// </summary>
        /// <remarks>
        /// This class includes devices that control the operation of multifunction IEEE 1284.4 peripheral devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Dot4 = new DeviceSetupClassGuids(
            "IEEE 1284.4 Devices",
            "Dot4",
            new Guid("{48721b56-6795-11d2-b1a8-0080c72e74a2}"),
            "This class includes devices that control the operation of multifunction IEEE 1284.4 peripheral devices.");

        /// <summary>
        /// IEEE 1284.4 Print Functions
        /// </summary>
        /// <remarks>
        /// This class includes Dot4 print functions. A Dot4 print function is a function on a Dot4 device and has a single child device, which is a member of the Printer device setup class.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Dot4Print = new DeviceSetupClassGuids(
            "IEEE 1284.4 Print Functions",
            "Dot4Print",
            new Guid("{49ce6ac8-6f86-11d2-b1e5-0080c72e74a2}"),
            "This class includes Dot4 print functions. A Dot4 print function is a function on a Dot4 device and has a single child device, which is a member of the Printer device setup class.");

        /// <summary>
        /// IEEE 1394 Devices That Support the 61883 Protocol
        /// </summary>
        /// <remarks>
        /// This class includes IEEE 1394 devices that support the IEC-61883 protocol device class. The 61883 component includes the 61883.sys protocol driver that transmits various audio and video data streams over the 1394 bus. These currently include standard/high/low quality DV, MPEG2, DSS, and Audio. These data streams are defined by the IEC-61883 specifications.
        /// </remarks>
        public static readonly DeviceSetupClassGuids _61883 = new DeviceSetupClassGuids(
            "IEEE 1394 Devices That Support the 61883 Protocol",
            "61883",
            new Guid("{7ebefbc0-3200-11d2-b4c2-00a0C9697d07}"),
            "This class includes IEEE 1394 devices that support the IEC-61883 protocol device class. The 61883 component includes the 61883.sys protocol driver that transmits various audio and video data streams over the 1394 bus. These currently include standard/high/low quality DV, MPEG2, DSS, and Audio. These data streams are defined by the IEC-61883 specifications.");

        /// <summary>
        /// IEEE 1394 Devices That Support the AVC Protocol
        /// </summary>
        /// <remarks>
        /// This class includes IEEE 1394 devices that support the AVC protocol device class.
        /// </remarks>
        public static readonly DeviceSetupClassGuids AVC = new DeviceSetupClassGuids(
            "IEEE 1394 Devices That Support the AVC Protocol",
            "AVC",
            new Guid("{c06ff265-ae09-48f0-812c-16753d7cba83}"),
            "This class includes IEEE 1394 devices that support the AVC protocol device class.");

        /// <summary>
        /// IEEE 1394 Devices That Support the SBP2 Protocol
        /// </summary>
        /// <remarks>
        /// This class includes IEEE 1394 devices that support the SBP2 protocol device class.
        /// </remarks>
        public static readonly DeviceSetupClassGuids SBP2 = new DeviceSetupClassGuids(
            "IEEE 1394 Devices That Support the SBP2 Protocol",
            "SBP2",
            new Guid("{d48179be-ec20-11d1-b6b8-00c04fa372a7}"),
            "This class includes IEEE 1394 devices that support the SBP2 protocol device class.");

        /// <summary>
        /// IEEE 1394 Host Bus Controller
        /// </summary>
        /// <remarks>
        /// This class includes 1394 host controllers connected on a PCI bus, but not 1394 peripherals. Drivers for this class are system-supplied.
        /// </remarks>
        public static readonly DeviceSetupClassGuids _1394 = new DeviceSetupClassGuids(
            "IEEE 1394 Host Bus Controller",
            "1394",
            new Guid("{6bdd1fc1-810f-11d0-bec7-08002be2092f}"),
            "This class includes 1394 host controllers connected on a PCI bus, but not 1394 peripherals. Drivers for this class are system-supplied.");

        /// <summary>
        /// Imaging Device
        /// </summary>
        /// <remarks>
        /// This class includes still-image capture devices, digital cameras, and scanners.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Image = new DeviceSetupClassGuids(
            "Imaging Device",
            "Image",
            new Guid("{6bdd1fc6-810f-11d0-bec7-08002be2092f}"),
            "This class includes still-image capture devices, digital cameras, and scanners.");

        /// <summary>
        /// IrDA Devices
        /// </summary>
        /// <remarks>
        /// This class includes infrared devices. Drivers for this class include Serial-IR and Fast-IR NDIS miniports, but see also the Network Adapter class for other NDIS network adapter miniports.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Infrared = new DeviceSetupClassGuids(
            "IrDA Devices",
            "Infrared",
            new Guid("{6bdd1fc5-810f-11d0-bec7-08002be2092f}"),
            "This class includes infrared devices. Drivers for this class include Serial-IR and Fast-IR NDIS miniports, but see also the Network Adapter class for other NDIS network adapter miniports.");

        /// <summary>
        /// Keyboard
        /// </summary>
        /// <remarks>
        /// This class includes all keyboards. That is, it must also be specified in the (secondary) INF for an enumerated child HID keyboard device.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Keyboard = new DeviceSetupClassGuids(
            "Keyboard",
            "Keyboard",
            new Guid("{4d36e96b-e325-11ce-bfc1-08002be10318}"),
            "This class includes all keyboards. That is, it must also be specified in the (secondary) INF for an enumerated child HID keyboard device.");

        /// <summary>
        /// Media Changers
        /// </summary>
        /// <remarks>
        /// This class includes SCSI media changer devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids MediumChanger = new DeviceSetupClassGuids(
            "Media Changers",
            "MediumChanger",
            new Guid("{ce5939ae-ebde-11d0-b181-0000f8753ec4}"),
            "This class includes SCSI media changer devices.");

        /// <summary>
        /// Memory Technology Driver
        /// </summary>
        /// <remarks>
        /// This class includes memory devices, such as flash memory cards.
        /// </remarks>
        public static readonly DeviceSetupClassGuids MTD = new DeviceSetupClassGuids(
            "Memory Technology Driver",
            "MTD",
            new Guid("{4d36e970-e325-11ce-bfc1-08002be10318}"),
            "This class includes memory devices, such as flash memory cards.");

        /// <summary>
        /// Modem
        /// </summary>
        /// <remarks>
        /// This class includes modem devices. An INF file for a device of this class specifies the features and configuration of the device and stores this information in the registry. An INF file for a device of this class can also be used to install device drivers for a controllerless modem or a software modem. These devices split the functionality between the modem device and the device driver. For more information about modem INF files and Microsoft Windows Driver Model (WDM) modem devices, see Overview of Modem INF Files and Adding WDM Modem Support.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Modem = new DeviceSetupClassGuids(
            "Modem",
            "Modem",
            new Guid("{4d36e96d-e325-11ce-bfc1-08002be10318}"),
            "This class includes modem devices. An INF file for a device of this class specifies the features and configuration of the device and stores this information in the registry. An INF file for a device of this class can also be used to install device drivers for a controllerless modem or a software modem. These devices split the functionality between the modem device and the device driver. For more information about modem INF files and Microsoft Windows Driver Model (WDM) modem devices, see Overview of Modem INF Files and Adding WDM Modem Support.");

        /// <summary>
        /// Monitor
        /// </summary>
        /// <remarks>
        /// This class includes display monitors. An INF for a device of this class installs no device driver(s), but instead specifies the features of a particular monitor to be stored in the registry for use by drivers of video adapters. (Monitors are enumerated as the child devices of display adapters.)
        /// </remarks>
        public static readonly DeviceSetupClassGuids Monitor = new DeviceSetupClassGuids(
            "Monitor",
            "Monitor",
            new Guid("{4d36e96e-e325-11ce-bfc1-08002be10318}"),
            "This class includes display monitors. An INF for a device of this class installs no device driver(s), but instead specifies the features of a particular monitor to be stored in the registry for use by drivers of video adapters. (Monitors are enumerated as the child devices of display adapters.)");

        /// <summary>
        /// Mouse
        /// </summary>
        /// <remarks>
        /// This class includes all mouse devices and other kinds of pointing devices, such as trackballs. That is, this class must also be specified in the (secondary) INF for an enumerated child HID mouse device.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Mouse = new DeviceSetupClassGuids(
            "Mouse",
            "Mouse",
            new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}"),
            "This class includes all mouse devices and other kinds of pointing devices, such as trackballs. That is, this class must also be specified in the (secondary) INF for an enumerated child HID mouse device.");

        /// <summary>
        /// Multiport Serial Adapters
        /// </summary>
        /// <remarks>
        /// This class includes intelligent multiport serial cards, but not peripheral devices that connect to its ports. It does not include unintelligent (16550-type) multiport serial controllers or single-port serial controllers (see the Ports class).
        /// </remarks>
        public static readonly DeviceSetupClassGuids Multifunction = new DeviceSetupClassGuids(
            "Multifunction Devices",
            "Multifunction",
            new Guid("{4d36e971-e325-11ce-bfc1-08002be10318}"),
            "This class includes combo cards, such as a PCMCIA modem and netcard adapter. The driver for such a Plug and Play multifunction device is installed under this class and enumerates the modem and netcard separately as its child devices.");

        /// <summary>
        /// Multimedia
        /// </summary>
        /// <remarks>
        /// This class includes Audio and DVD multimedia devices, joystick ports, and full-motion video capture devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Media = new DeviceSetupClassGuids(
            "Multimedia",
            "Media",
            new Guid("{4d36e96c-e325-11ce-bfc1-08002be10318}"),
            "This class includes Audio and DVD multimedia devices, joystick ports, and full-motion video capture devices.");

        /// <summary>
        /// Multiport Serial Adapters
        /// </summary>
        /// <remarks>
        /// This class includes intelligent multiport serial cards, but not peripheral devices that connect to its ports. It does not include unintelligent (16550-type) multiport serial controllers or single-port serial controllers (see the Ports class).
        /// </remarks>
        public static readonly DeviceSetupClassGuids MultiportSerial = new DeviceSetupClassGuids(
            "Multiport Serial Adapters",
            "MultiportSerial",
            new Guid("{50906cb8-ba12-11d1-bf5d-0000f805f530}"),
            "This class includes intelligent multiport serial cards, but not peripheral devices that connect to its ports. It does not include unintelligent (16550-type) multiport serial controllers or single-port serial controllers (see the Ports class).");

        /// <summary>
        /// Network Adapter
        /// </summary>
        /// <remarks>
        /// This class consists of network adapter drivers. These drivers must either call NdisMRegisterMiniportDriver or NetAdapterCreate. Drivers that do not use NDIS or NetAdapter should use a different setup class.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Net = new DeviceSetupClassGuids(
            "Network Adapter",
            "Net",
            new Guid("{4d36e972-e325-11ce-bfc1-08002be10318}"),
            "This class consists of network adapter drivers. These drivers must either call NdisMRegisterMiniportDriver or NetAdapterCreate. Drivers that do not use NDIS or NetAdapter should use a different setup class.");

        /// <summary>
        /// Network Client
        /// </summary>
        /// <remarks>
        /// This class includes network and/or print providers. Note that NetClient components are deprecated in Windows 8.1, Windows Server 2012 R2, and later.
        /// </remarks>
        public static readonly DeviceSetupClassGuids NetClient = new DeviceSetupClassGuids(
            "Network Client",
            "NetClient",
            new Guid("{4d36e973-e325-11ce-bfc1-08002be10318}"),
            "This class includes network and/or print providers. Note that NetClient components are deprecated in Windows 8.1, Windows Server 2012 R2, and later.");

        /// <summary>
        /// Network Service
        /// </summary>
        /// <remarks>
        /// This class includes network services, such as redirectors and servers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids NetService = new DeviceSetupClassGuids(
            "Network Service",
            "NetService",
            new Guid("{4d36e974-e325-11ce-bfc1-08002be10318}"),
            "This class includes network services, such as redirectors and servers.");

        /// <summary>
        /// Network Transport
        /// </summary>
        /// <remarks>
        /// This class includes NDIS protocols CoNDIS stand-alone call managers, and CoNDIS clients, in addition to higher level drivers in transport stacks.
        /// </remarks>
        public static readonly DeviceSetupClassGuids NetTrans = new DeviceSetupClassGuids(
            "Network Transport",
            "NetTrans",
            new Guid("{4d36e975-e325-11ce-bfc1-08002be10318}"),
            "This class includes NDIS protocols CoNDIS stand-alone call managers, and CoNDIS clients, in addition to higher level drivers in transport stacks.");

        /// <summary>
        /// PCI SSL Accelerator
        /// </summary>
        /// <remarks>
        /// This class includes devices that accelerate secure socket layer (SSL) cryptographic processing.
        /// </remarks>
        public static readonly DeviceSetupClassGuids SecurityAccelerator = new DeviceSetupClassGuids(
            "PCI SSL Accelerator",
            "SecurityAccelerator",
            new Guid("{268c95a1-edfe-11d3-95c3-0010dc4050a5}"),
            "This class includes devices that accelerate secure socket layer (SSL) cryptographic processing.");

        /// <summary>
        /// PCMIA Adapters
        /// </summary>
        /// <remarks>
        /// This class includes PCMCIA and CardBus host controllers, but not PCMCIA or CardBus peripherals. Drivers for this class are system-supplied.
        /// </remarks>
        public static readonly DeviceSetupClassGuids PCMCIA = new DeviceSetupClassGuids(
            "PCMCIA Adapters",
            "PCMCIA",
            new Guid("{4d36e977-e325-11ce-bfc1-08002be10318}"),
            "This class includes PCMCIA and CardBus host controllers, but not PCMCIA or CardBus peripherals. Drivers for this class are system-supplied.");

        /// <summary>
        /// Ports (COM &amp; LPT ports)
        /// </summary>
        /// <remarks>
        /// This class includes serial and parallel port devices. See also the MultiportSerial class.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Ports = new DeviceSetupClassGuids(
            "Ports (COM & LPT ports)",
            "Ports",
            new Guid("{4d36e978-e325-11ce-bfc1-08002be10318}"),
            "This class includes serial and parallel port devices. See also the MultiportSerial class.");

        /// <summary>
        /// Printers
        /// </summary>
        /// <remarks>
        /// This class includes printers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Printer = new DeviceSetupClassGuids(
            "Printers",
            "Printer",
            new Guid("{4d36e979-e325-11ce-bfc1-08002be10318}"),
            "This class includes printers.");

        /// <summary>
        /// Printers, Bus-specific class drivers
        /// </summary>
        /// <remarks>
        /// This class includes SCSI/1394-enumerated printers. Drivers for this class provide printer communication for a specific bus.
        /// </remarks>
        public static readonly DeviceSetupClassGuids PNPPrinters = new DeviceSetupClassGuids(
            "Printers, Bus-specific class drivers",
            "PNPPrinters",
            new Guid("{4658ee7e-f050-11d1-b6bd-00c04fa372a7}"),
            "This class includes SCSI/1394-enumerated printers. Drivers for this class provide printer communication for a specific bus.");

        /// <summary>
        /// Processor
        /// </summary>
        /// <remarks>
        /// This class includes processor types.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Processor = new DeviceSetupClassGuids(
            "Processors",
            "Processor",
            new Guid("{50127dc3-0f36-415e-a6cc-4cb3be910b65}"),
            "This class includes processor types.");

        /// <summary>
        /// SCSI and RAID Controllers
        /// </summary>
        /// <remarks>
        /// This class includes SCSI HBAs (Host Bus Adapters) and disk-array controllers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids SCSIAdapter = new DeviceSetupClassGuids(
            "SCSI and RAID Controllers",
            "SCSIAdapter",
            new Guid("{4d36e97b-e325-11ce-bfc1-08002be10318}"),
            "This class includes SCSI HBAs (Host Bus Adapters) and disk-array controllers.");

        /// <summary>
        /// Security Devices
        /// </summary>
        /// <remarks>
        /// (Windows 8.1, Windows 10) This class includes Trusted Platform Module chips. A TPM is a secure crypto-processor that helps you with actions such as generating, storing, and limiting the use of cryptographic keys. Any new manufactured device must implement and enable TPM 2.0 by default. For more information, see TPM Recommendations.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Securitydevices = new DeviceSetupClassGuids(
            "Security Devices",
            "Securitydevices",
            new Guid("{d94ee5d8-d189-4994-83d2-f68d7d41b0e6}"),
            "(Windows 8.1, Windows 10) This class includes Trusted Platform Module chips. A TPM is a secure crypto-processor that helps you with actions such as generating, storing, and limiting the use of cryptographic keys. Any new manufactured device must implement and enable TPM 2.0 by default. For more information, see TPM Recommendations.");

        /// <summary>
        /// Sensors
        /// </summary>
        /// <remarks>
        /// (Windows 7 and later versions of Windows) This class includes sensor and location devices, such as GPS devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Sensor = new DeviceSetupClassGuids(
            "Sensors",
            "Sensor",
            new Guid("{5175d334-c371-4806-b3ba-71fd53c9258d}"),
            "(Windows 7 and later versions of Windows) This class includes sensor and location devices, such as GPS devices.");

        /// <summary>
        /// Smart Card Readers
        /// </summary>
        /// <remarks>
        /// This class includes smart card readers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids SmartCardReader = new DeviceSetupClassGuids(
            "Smart Card Readers",
            "SmartCardReader",
            new Guid("{50dd5230-ba8a-11d1-bf5d-0000f805f530}"),
            "This class includes smart card readers.");

        /// <summary>
        /// Software Component
        /// </summary>
        /// <remarks>
        /// (Windows 10 version 1703 and later versions of Windows) This class includes virtual child device to encapsulate software components. For more details, see Adding Software Components with an INF file.
        /// </remarks>
        public static readonly DeviceSetupClassGuids SoftwareComponent = new DeviceSetupClassGuids(
            "Software Component",
            "SoftwareComponent",
            new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}"),
            "(Windows 10 version 1703 and later versions of Windows) This class includes virtual child device to encapsulate software components. For more details, see Adding Software Components with an INF file.");

        /// <summary>
        /// Storage Volumes
        /// </summary>
        /// <remarks>
        /// This class includes storage volumes as defined by the system-supplied logical volume manager and class drivers that create device objects to represent storage volumes, such as the system disk class driver.
        /// </remarks>
        public static readonly DeviceSetupClassGuids Volume = new DeviceSetupClassGuids(
            "Storage Volumes",
            "Volume",
            new Guid("{71a27cdd-812a-11d0-bec7-08002be2092f}"),
            "This class includes storage volumes as defined by the system-supplied logical volume manager and class drivers that create device objects to represent storage volumes, such as the system disk class driver.");

        /// <summary>
        /// System Devices
        /// </summary>
        /// <remarks>
        /// This class includes HALs, system buses, system bridges, the system ACPI driver, and the system volume manager driver.
        /// </remarks>
        public static readonly DeviceSetupClassGuids System = new DeviceSetupClassGuids(
            "System Devices",
            "System",
            new Guid("{4d36e97d-e325-11ce-bfc1-08002be10318}"),
            "This class includes HALs, system buses, system bridges, the system ACPI driver, and the system volume manager driver.");

        /// <summary>
        /// Tape Drives
        /// </summary>
        /// <remarks>
        /// This class includes tape drives, including all tape miniclass drivers.
        /// </remarks>
        public static readonly DeviceSetupClassGuids TapeDrive = new DeviceSetupClassGuids(
            "Tape Drives",
            "TapeDrive",
            new Guid("{6d807884-7d21-11cf-801c-08002be10318}"),
            "This class includes tape drives, including all tape miniclass drivers.");

        /// <summary>
        /// USB Device
        /// </summary>
        /// <remarks>
        /// USBDevice includes all USB devices that do not belong to another class. This class is not used for USB host controllers and hubs.
        /// </remarks>
        public static readonly DeviceSetupClassGuids USBDevice = new DeviceSetupClassGuids(
            "USB Device",
            "USBDevice",
            new Guid("{88BAE032-5A81-49f0-BC3D-A4FF138216D6}"),
            "USBDevice includes all USB devices that do not belong to another class. This class is not used for USB host controllers and hubs.");

        /// <summary>
        /// Windows CE ActiveSync Devices
        /// </summary>
        /// <remarks>
        /// This class includes Windows CE ActiveSync devices. The WCEUSBS setup class supports communication between a personal computer and a device that is compatible with the Windows CE ActiveSync driver (generally, PocketPC devices) over USB.
        /// </remarks>
        public static readonly DeviceSetupClassGuids WCEUSBS = new DeviceSetupClassGuids(
            "Windows CE USB ActiveSync Devices",
            "WCEUSBS",
            new Guid("{25dbce51-6c8f-4a72-8a6d-b54c2b4fc835}"),
            "This class includes Windows CE ActiveSync devices. The WCEUSBS setup class supports communication between a personal computer and a device that is compatible with the Windows CE ActiveSync driver (generally, PocketPC devices) over USB.");

        /// <summary>
        /// Windows Portable Devices (WPD)
        /// </summary>
        /// <remarks>
        /// (Windows Vista and later versions of Windows) This class includes WPD devices.
        /// </remarks>
        public static readonly DeviceSetupClassGuids WPD = new DeviceSetupClassGuids(
            "Windows Portable Devices (WPD)",
            "WPD",
            new Guid("{eec5ad98-8080-425f-922a-dabf3de3f69a}"),
            "(Windows Vista and later versions of Windows) This class includes WPD devices.");
    }
}
