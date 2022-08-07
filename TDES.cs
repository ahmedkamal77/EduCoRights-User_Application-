using System.Text;
using System.Security.Cryptography;

namespace tribleedes
{
     public class TDES
    {

        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public TDES (string key)
        {
           
            des.Key = UTF8Encoding.UTF8.GetBytes(key); //encoding type
            des.Mode = CipherMode.ECB;  //electronic code book
            des.Padding = PaddingMode.PKCS7;

        }
        
        public byte[] decfile(byte[] bytes)
        {
            byte[] dec_byte = des.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            return dec_byte;
        }

    }
}

