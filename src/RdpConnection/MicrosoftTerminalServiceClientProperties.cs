#if NETSTANDARD2_0_OR_GREATER

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace RdpConnection
{
    /// <summary>
    /// Microsoft Terminal Service Client Properties.
    /// </summary>
    [DataContract]
    public class MicrosoftTerminalServiceClientProperties : RemoteDesktopClientProperties
    {
        /// <summary>
        /// Password (Only Windows NT, Current User, Unicode Encoding).
        /// </summary>
        /// <remarks>
        /// The password value supplied for this property is for Windows NT systems only, can only be encrypted and decrypted by the user currently logged in to the computer and running the code, and must use Unicode encoding.
        /// </remarks>
        [DisplayName("Password (Only Windows NT, Current User, Unicode Encoding)")]
        [Description("The password value supplied for this property is for Windows NT systems only, can only be encrypted and decrypted by the user currently logged in to the computer and running the code, and must use Unicode encoding.")]
        [DataMember(Name = "password 51")]
        public byte[] Password { get; set; }

        /// <summary>
        /// Set the password.
        /// </summary>
        /// <param name="rawPassword">
        /// Unencrypted password.
        /// </param>
        public void SetPassword(string rawPassword)
            => Password = ProtectedData.Protect(Encoding.Unicode.GetBytes(rawPassword), default, DataProtectionScope.CurrentUser);

        /// <summary>
        /// Get the password.
        /// </summary>
        /// <remarks>
        /// The user and computer that called the SetPassword function must match for GetPassword to get the restored password.
        /// </remarks>
        /// <returns>
        /// Unencrypted password.
        /// </returns>
        public string GetPassword()
        {
            var pwdBytes = ProtectedData.Unprotect(Password, default, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(pwdBytes, 0, pwdBytes.Length);
        }

        /// <summary>
        /// Redact the password.
        /// </summary>
        public void RedactPassword()
            => SetPassword(string.Empty);
    }
}

#endif // NETSTANDARD2_0_OR_GREATER
