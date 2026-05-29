using System;
using System.Security.Cryptography;
using System.Text;

namespace Bai1.Crypto
{
    public static class HashData
    {
        private const string PublicKeyXml = @"<RSAKeyValue><Modulus>PASTE_PUBLIC_MODULUS_HERE</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private const string PrivateKeyXml = @"<RSAKeyValue><Modulus>PASTE_PRIVATE_MODULUS_HERE</Modulus><Exponent>AQAB</Exponent><P>...</P><Q>...</Q><DP>...</DP><DQ>...</DQ><InverseQ>...</InverseQ><D>...</D></RSAKeyValue>";
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
                rsa.FromXmlString(PrivateKeyXml);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data ?? string.Empty);
                byte[] signatureBytes = rsa.SignData(dataBytes, CryptoConfig.MapNameToOID("SHA256"));
                return Convert.ToBase64String(signatureBytes);
            }
        }

        public static bool Verify(string data, string signature)
        {
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(signature))
                return false;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(PublicKeyXml);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] sigBytes = Convert.FromBase64String(signature);
                return rsa.VerifyData(dataBytes, CryptoConfig.MapNameToOID("SHA256"), sigBytes);
            }
        }
    }
}