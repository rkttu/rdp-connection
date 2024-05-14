using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace RdpConnection;

// https://github.com/RedAndBlueEraser/rdp-file-password-encryptor
[DataContract]
public class MicrosoftTerminalServiceClientProperties : RemoteDesktopClientProperties
{
    [DisplayName("Password (Only Windows NT, Current User, Unicode Encoding)")]
    [Description("The password value supplied for this property is for Windows NT systems only, can only be encrypted and decrypted by the user currently logged in to the computer and running the code, and must use Unicode encoding.")]
    [DataMember(Name = "password 51")]
    public byte[]? Password { get; set; }

    public void SetPassword(string rawPassword)
        => Password = Encoding.Unicode.GetBytes(rawPassword);

    public string? GetPassword()
        => Encoding.Unicode.GetString(Password ?? new byte[] { });

    public void RedactPassword()
        => Password = default;
}
