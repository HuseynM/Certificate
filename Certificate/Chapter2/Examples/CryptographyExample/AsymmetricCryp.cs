using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.CryptographyExample
{
    public class AsymmetricCryp
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        string publicKeyXML = string.Empty;
        string privateKeyXML = string.Empty;
        public  void GenerateKeys()
        {
            publicKeyXML = rsa.ToXmlString(false);
            privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine(publicKeyXML+"\n\n\n\n");
            Console.WriteLine(privateKeyXML);
        }

        public void Execute()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");
            byte[] encryptedData;

            publicKeyXML = rsa.ToXmlString(false);
            privateKeyXML = rsa.ToXmlString(true);

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }
            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }  
    }
}
