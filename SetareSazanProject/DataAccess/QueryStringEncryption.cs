using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SetareSazanProject.DataAccess
{
    public class QueryStringEncryption
    {
        private static string Key = "0^s~$w17#!,pakzad";
        private static byte[] GetByte(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static byte[] EncryptString(string data)
        {
            byte[] byteData = GetByte(data);
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            algo.GenerateIV();

            MemoryStream mStream = new MemoryStream();
            mStream.Write(algo.IV, 0, algo.IV.Length);

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateEncryptor(), CryptoStreamMode.Write);
            myCrypto.Write(byteData, 0, byteData.Length);
            myCrypto.FlushFinalBlock();

            return mStream.ToArray();
        }

        public static string DecryptString(byte[] data)
        {
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            MemoryStream mStream = new MemoryStream();

            byte[] byteData = new byte[algo.IV.Length];
            Array.Copy(data, byteData, byteData.Length);
            algo.IV = byteData;
            int readFrom = 0;
            readFrom += algo.IV.Length;

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateDecryptor(), CryptoStreamMode.Write);
            myCrypto.Write(data, readFrom, data.Length - readFrom);
            myCrypto.FlushFinalBlock();

            return Encoding.UTF8.GetString(mStream.ToArray());
        }

        public static string GetEncryptedQueryString(string data)
        {
            return Convert.ToBase64String(EncryptString(data));
        }

        public static string GetDecryptedQueryString(string data)
        {
            byte[] byteData = Convert.FromBase64String(data.Replace(" ", "+"));
            return DecryptString(byteData);
        }
    }
}
