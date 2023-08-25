using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SetareSazanProject.DataAccess
{
    public static class DataBaseConnection
    {
        public static string GetConnectFilePath()
        {
            string filePath = Path.Combine(Application.StartupPath, "Connect.xml");
            string fileName = Path.GetFileName(filePath);
            return fileName;
        }

        public static string ReadConnection(string filename)
        {
            string conectionstring = "";
            if(File.Exists(filename))
            {
                XmlTextReader x = new XmlTextReader(filename);
                string s = x.ReadElementString("Connection");
                x.Close();
                string[] s1 = new string[4];
                string[] s2 = new string[1];
                s2[0] = ";";
                s1 = s.Split(s2, StringSplitOptions.RemoveEmptyEntries);
                switch (s1.Length)
                {
                    case 3:
                        conectionstring = s1[0] + ";" + s1[1] + ";" + s1[2];
                        break;
                    case 6:
                        conectionstring = s1[0] + ";" + s1[1] + ";" + s1[2] + ";" + s1[3] + ";" + s1[4] + ";" + s1[5];
                        break;
                    case 4:
                        conectionstring = s1[0] + ";" + s1[1] + ";" + s1[2] + ";Password=" + DecryptString(s1[3].Remove(0, 9));
                        break;
                    default:
                        conectionstring = s1[0] + ";" + s1[1] + ";" + s1[2] + ";Password=" + DecryptString(s1[3].Remove(0, 9));
                        break;
                }
            }
            return conectionstring;
        }

        public static string DecryptString(string EncryptText)
        {
            byte[] IV = { 0, 254, 100, 7, 17, 180, 255, 1 };
            string Key = "0^s~$w17#!,pakzad";
            byte[] decodeText;
            try
            {
                byte[] buffer = Convert.FromBase64String(EncryptText);
                TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                triple.IV = IV;
                triple.Key = md5.ComputeHash(buffer: Encoding.UTF8.GetBytes(Key));
                decodeText = triple.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length);
            }
            catch
            {
                return EncryptText;
            }
            return Encoding.UTF8.GetString(decodeText);
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static int ToInt(this object value)
        {
            int a = 0;
            try
            {
                a = Convert.ToInt32(value);
            }
            catch
            {
            }
            return a;
        }
    }
}
