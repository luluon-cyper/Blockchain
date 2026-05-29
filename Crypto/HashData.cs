using System;
using System.Security.Cryptography;
using System.Text;

namespace Bai1.Crypto
{
    public static class HashData
    {
        public static string Hash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));
                return Convert.ToBase64String(bytes);
            }
        }

        public static (string Signature, string PublicKey) Sign(string data)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                byte[] signatureBytes = rsa.SignData(
                    dataBytes,
                    HashAlgorithmName.SHA256,
                    RSASignaturePadding.Pkcs1);

                string Signature = Convert.ToBase64String(signatureBytes);
                string PublicKey = rsa.ToXmlString(false);

                return (Signature, PublicKey);
            }
        }
    }
}