using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string OriginalData = "Abdelrahman";
            //string HashedData = ComputeHash(OriginalData);

            // Symmetric Encryption
            string Key = "PWRVjO7NwmZkkomV";
            string EncryptedData = EncryptAES(OriginalData, Key);
            string DecryptedData = DecryptAES(EncryptedData, Key);

            Console.WriteLine($"Original Data: {OriginalData}");
            //Console.WriteLine($"hashed Data  : {HashedData}");

            Console.WriteLine($"Encrypted Data: {EncryptedData}");
            Console.WriteLine($"Decrypted Data: {DecryptedData}");

            try
            {
                // Generate public and private key pair
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    // Get the public key
                    /*
                     When exporting the public key, ToXmlString(false) is used with the argument set 
                     to false to indicate that only the public parameters should be included in the XML string.
                     */
                    string publicKey = rsa.ToXmlString(false);


                    // Get the private key
                    string privateKey = rsa.ToXmlString(true);


                    // Original message
                    string originalMessage = "Hello, this is a secret message!";


                    // Encrypt using the public key
                    string encryptedMessage = EncryptRSA(originalMessage, publicKey);


                    // Decrypt using the private key
                    string decryptedMessage = DecryptRSA(encryptedMessage, privateKey);


                    // Display the results
                    Console.WriteLine($"\n\nPublic Key:\n {publicKey}");
                    Console.WriteLine($"\n\nPrivate Key:\n {privateKey}");
                    Console.WriteLine($"\nOriginal Message:\n {originalMessage}");
                    Console.WriteLine($"\nEncrypted Message:\n {encryptedMessage}");
                    Console.WriteLine($"\nDecrypted Message:\n {decryptedMessage}");


                    // Wait for user input before closing the console window
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Encryption/Decryption error: {ex.Message}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ReadKey();
            }
        }

        static string ComputeHash(string Input)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        static string EncryptAES(string PlainText, string Key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                // Create an Encryptor
                ICryptoTransform Encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, Encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(PlainText);
                    }

                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        static string DecryptAES(string CipherText, string Key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                // Create a Decryptor
                ICryptoTransform Decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(CipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        static string EncryptRSA(string plainText, string publicKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);


                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
                    return Convert.ToBase64String(encryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Encryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }

        static string DecryptRSA(string cipherText, string privateKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);


                    byte[] encryptedData = Convert.FromBase64String(cipherText);
                    byte[] decryptedData = rsa.Decrypt(encryptedData, false);


                    return Encoding.UTF8.GetString(decryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Decryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }
    }
}
