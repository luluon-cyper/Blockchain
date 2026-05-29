using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bai1.Crypto
{
    public static class HashData
    {
        private static readonly string KeyDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "keys");

        private static readonly string PrivateKeyPath =
            Path.Combine(KeyDir, "private.xml");

        private static readonly string PublicKeyPath =
            Path.Combine(KeyDir, "public.xml");

        static HashData()
        {
            EnsureKeyPair();
        }

        public static void EnsureKeyPair()
        {
            if (File.Exists(PrivateKeyPath) && File.Exists(PublicKeyPath))
                return;

            Directory.CreateDirectory(KeyDir);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                File.WriteAllText(PrivateKeyPath, rsa.ToXmlString(true));
                File.WriteAllText(PublicKeyPath, rsa.ToXmlString(false));
            }
        }

        private static string LoadPrivateKey()
        {
            EnsureKeyPair();
            return File.ReadAllText(PrivateKeyPath);
        }

        private static string LoadPublicKey()
        {
            EnsureKeyPair();
            return File.ReadAllText(PublicKeyPath);
        }

        public static string Hash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));
                return Convert.ToBase64String(bytes);
            }
        }

        public static string Sign(string data)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(LoadPrivateKey());

                byte[] dataBytes = Encoding.UTF8.GetBytes(data ?? string.Empty);
                byte[] sigBytes = rsa.SignData(dataBytes, CryptoConfig.MapNameToOID("SHA256"));

                return Convert.ToBase64String(sigBytes);
            }
        }

        public static bool Verify(string data, string signature)
        {
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(signature))
                return false;

            try
            {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(LoadPublicKey());

                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    byte[] sigBytes = Convert.FromBase64String(signature);

                    return rsa.VerifyData(dataBytes, CryptoConfig.MapNameToOID("SHA256"), sigBytes);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}