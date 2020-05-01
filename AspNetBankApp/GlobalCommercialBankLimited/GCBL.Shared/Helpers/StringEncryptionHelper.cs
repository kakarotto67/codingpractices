using System;
using System.Security.Cryptography;
using System.Text;

namespace GCBL.Shared.Helpers
{
    public static class StringEncryptionHelper
    {
        private static readonly byte[] Entropy = {2, 5, 123, 2, 5, 7, 53, 2, 7, 4, 9, 95, 31};

        public static string Encrypt(this string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return original;
            }

            var originalBytes = Encoding.UTF8.GetBytes(original);
            var encryptedBytes = ProtectedData.Protect(originalBytes, Entropy, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encrypted)
        {
            if (String.IsNullOrEmpty(encrypted))
            {
                return encrypted;
            }

            var encryptedBytes = Convert.FromBase64String(encrypted);
            var originalBytes = ProtectedData.Unprotect(encryptedBytes, Entropy, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(originalBytes);
        }
    }
}