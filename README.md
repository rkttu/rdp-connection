# RdpConnection

A library that provides RDP file generation and analysis and RDP URL generation capabilities for Remote Desktop Client, Remote Desktop Service, Azure Virtual Desktop, and Microsoft Terminal Service Client.

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

## License

This library is distributed under the Apache-2.0 License.
