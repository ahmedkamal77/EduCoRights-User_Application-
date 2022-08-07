using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace aes256withsalt
{
    class cryptor
    {
        
        public static byte[] getdecryptor(string strkey, byte[] textByte, string strsalt)
        {
            byte [] keybyte = Encoding.UTF8.GetBytes(strkey);
            byte [] saltbyte = null;
            if (string.IsNullOrEmpty(strsalt))
            {
                saltbyte = new byte[] { 0x14, 0x00, 0x77, 0x55, 0x02, 0x04, 0x88, 0x99, 0x14, 0x50, 0x71, 0x55, 0x52, 0x04, 0x48, 0x00 };

            }
            else
            {
                saltbyte = Encoding.UTF8.GetBytes(strsalt);
            }
            byte[] encryptedfile = null;

            try
            {
                using (var memmory = new MemoryStream())
                {
                    using (var aes = new RijndaelManaged())
                    {
                        aes.Mode = CipherMode.CBC;
                        aes.Padding = PaddingMode.PKCS7;
                        aes.KeySize = 256;
                        aes.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(keybyte, saltbyte, 2000);  //دمج 
                        aes.Key = key.GetBytes(aes.KeySize / 8); //bytes
                        aes.IV = key.GetBytes(aes.BlockSize / 8);//bytes


                        using (var ICrypto = new CryptoStream(memmory, aes.CreateDecryptor(), CryptoStreamMode.Write))

                        {   //start decryption
                            ICrypto.Write(textByte, 0, textByte.Length);
                            //fininsh decrypting
                            ICrypto.FlushFinalBlock();
                            ICrypto.Close();


                        }

                    }
                    encryptedfile = memmory.ToArray();
                    memmory.Close();
                }
                return encryptedfile;

            }
            catch
            {

                return null;
            }
        }

    }
}
