using System.Security.Cryptography;
using System.Text;

namespace Pizzaria_back.Helpers
{
    public class CriptografiaHelper
    {
        private static void DeriveKeyAndIv(
            byte[] passphrase,
            byte[] salt,
            int iterations,
            out byte[] key,
            out byte[] iv
        )
        {
            var hashList = new List<byte>();
            var preHashLength = passphrase.Length + (salt?.Length ?? 0);
            var preHash = new byte[preHashLength];
            Buffer.BlockCopy(
                passphrase,
                0,
                preHash,
                0,
                passphrase.Length
            );
            if (salt != null)
            {
                Buffer.BlockCopy(
                    salt,
                    0,
                    preHash,
                    passphrase.Length,
                    salt.Length
                );
            }

            var hash = MD5.Create();
            var currentHash = hash.ComputeHash(preHash);
            for (var i = 1; i < iterations; i++)
            {
                currentHash = hash.ComputeHash(currentHash);
            }

            hashList.AddRange(currentHash);
            while (hashList.Count < 48)
            {
                preHashLength = currentHash.Length + passphrase.Length + (salt?.Length ?? 0);
                preHash = new byte[preHashLength];
                Buffer.BlockCopy(
                    currentHash,
                    0,
                    preHash,
                    0,
                    currentHash.Length
                );
                Buffer.BlockCopy(
                    passphrase,
                    0,
                    preHash,
                    currentHash.Length,
                    passphrase.Length
                );
                if (salt != null)
                {
                    Buffer.BlockCopy(
                        salt,
                        0,
                        preHash,
                        currentHash.Length + passphrase.Length,
                        salt.Length
                    );
                }

                currentHash = hash.ComputeHash(preHash);
                for (var i = 1; i < iterations; i++)
                {
                    currentHash = hash.ComputeHash(currentHash);
                }

                hashList.AddRange(currentHash);
            }

            hash.Clear();
            key = new byte[32];
            iv = new byte[16];
            hashList.CopyTo(
                0,
                key,
                0,
                32
            );
            hashList.CopyTo(
                32,
                iv,
                0,
                16
            );
        }

        public static string DescriptografarAes(string encryptedString, string passphrase)
        {
            var base64Bytes = Convert.FromBase64String(encryptedString);
            var saltBytes = base64Bytes[8..16];
            var cipherTextBytes = base64Bytes[16..];
            var passphraseBytes = Encoding.UTF8.GetBytes(passphrase);

            DeriveKeyAndIv(
                passphraseBytes,
                saltBytes,
                1,
                out var keyBytes,
                out var ivBytes
            );
            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;
            aes.KeySize = 256;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            var decryptor = aes.CreateDecryptor(keyBytes, ivBytes);
            using var msDecrypt = new MemoryStream(cipherTextBytes);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public static string CriptografarAes(string plainText, string passphrase)
        {
            var salt = new byte[8];
            var passphraseBytes = Encoding.UTF8.GetBytes(passphrase);
            DeriveKeyAndIv(
               passphraseBytes,
               salt,
               1,
               out var key,
               out var iv
            );
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            var encryptor = aes.CreateEncryptor(key, iv);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            swEncrypt.Write(plainText);
            swEncrypt.Flush();
            swEncrypt.Close();
            var encryptedBytes = msEncrypt.ToArray();
            var encryptedBytesWithSalt = new byte[salt.Length + encryptedBytes.Length + 8];
            Buffer.BlockCopy(Encoding.ASCII.GetBytes("Salted__"), 0, encryptedBytesWithSalt, 0, 8);
            Buffer.BlockCopy(salt, 0, encryptedBytesWithSalt, 8, salt.Length);
            Buffer.BlockCopy(encryptedBytes, 0, encryptedBytesWithSalt, salt.Length + 8, encryptedBytes.Length);
            return Convert.ToBase64String(encryptedBytesWithSalt);
        }
    }
}
