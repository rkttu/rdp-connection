# RdpConnection

[![NuGet Version](https://img.shields.io/nuget/v/RdpConnection)](https://www.nuget.org/packages/RdpConnection/) ![Build Status](https://github.com/rkttu/rdp-connection/actions/workflows/dotnet.yml/badge.svg) [![GitHub Sponsors](https://img.shields.io/github/sponsors/rkttu)](https://github.com/sponsors/rkttu/)

A library that provides RDP file generation and analysis and RDP URL generation capabilities for Remote Desktop Client, Remote Desktop Service, Azure Virtual Desktop, and Microsoft Terminal Service Client.

## Minimum Requirements

- Requires a platform with .NET Standard 1.1 or later (Except `MicrosoftTerminalServiceClientProperties` class).
  - Supported .NET Version: .NET Core 1.0+, .NET 5+, .NET Framework 4.5+, Mono 4.6+, UWP 8.0+, Unity 2018.1+
- Requires a platform with .NET Standard 2.0 or later (`MicrosoftTerminalServiceClientProperties` class), and Windows NT Operating System.
  - Supported .NET Version: .NET Core 2.0+, .NET 5+, .NET Framework 4.6.1+, Mono 5.4+, UWP 10.0.16299+, Unity 2018.1+

## How to use

### Parse RDP file

Read the RDP file and convert it to a C# class.

```csharp
var parsedResult = RdpSerializer.Deserialize<RemoteDesktopClientProperties>(
	File.ReadAllLines(@"C:\Users\rkttu\Documents\Default.rdp"));
```

### Generate RDP file with password

You can create a typical RDP text file like this

The password you specify is encrypted with a unique key assigned to the current user, so that if you move the file to another user on the computer, another computer, or another device, the password cannot be decrypted.

```csharp
var rdp = new MicrosoftTerminalServiceClientProperties()
{
	FullAddress = "web.contoso.com",
	ScreenModeId = 2, // 1: window mode, 2: full screen
};
rdp.SetPassword("Password");
File.WriteAllText(@"C:\Users\rkttu\Desktop\test.rdp", string.Join(Environment.NewLine, rdp.Serialize()), new UTF8Encoding(false));
```

### Generate RDP URI

Generate URLs for the iOS, macOS, and Android Remote Desktop apps.

```csharp
var rdpUri = new RemoteDesktopUriProperties()
{
	FullAddress = "web.contoso.com",
	ScreenModeId = 1, // 1: window mode, 2: full screen
};
var uri = rdpUri.SerializeAsRdpUri();
```

## Source code original author notice

- https://github.com/RedAndBlueEraser/rdp-file-password-encryptor

## License

This library is distributed under the Apache-2.0 License.
