/*
Author: Jayson Ragasa | aka: Nullstring
Application Developer - Anomalist Designs LLC
 * 
 * --
 * Made a wrapper for DataProtector so I could
 * Encrypt/Decrypt valid password for RDP
 * 
 * TAKE NOTE:
 * This can't Decrypt MSTSC Password!
*/
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DataProtection
namespace UIAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DataProtectionForRDPWrapper
    {
        //static DataProtection.DataProtector dp = new DataProtector(DataProtector.Store.USE_MACHINE_STORE);
        static DataProtector dp = new DataProtector(DataProtector.Store.USE_MACHINE_STORE);

        public static string Encrypt(string text_password)
        {
            byte[] e = dp.Encrypt(GetBytes(text_password), null, "psw");
            return GetHex(e);
        }

        public static string Decrypt(string enc_password)
        {
            byte[] b = ToByteArray(enc_password);
            byte[] d = dp.Decrypt(b, null, "psw");
            return GetString(d);
        }

        static byte[] GetBytes(string text)
        {
            return UnicodeEncoding.Unicode.GetBytes(text);
        }

        static string GetString(byte[] byt)
        {
            System.Text.Encoding enc = System.Text.Encoding.Unicode;
            return enc.GetString(byt);
        }

        static string GetHex(byte[] byt_text)
        {
            string ret = string.Empty;

            for (int i = 0; i < byt_text.Length; i++)
            {
                ret += Convert.ToString(byt_text[i], 16).PadLeft(2, '0').ToUpper();
            }

            return ret;
        }

        static byte[] ToByteArray(String HexString)
        {
            try
            {
                int NumberChars = HexString.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
                }
                return bytes;
            }
            catch (Exception ex)
            {
                // this occures everytime we decrypt MSTSC generated password.
                // so let's just throw an exception for now
                throw new Exception("Problem converting Hex to Bytes", ex);
            }
        }
    }
}
