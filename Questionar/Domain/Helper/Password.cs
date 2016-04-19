using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Domain.Helper
{
    public class Password
    {
        public static string Generate()
        {
            string password = GenerateRadomText(6);
            return Encrypty(password);
        }

        public static string Encrypty(string text)
        {
            HashAlgorithm hash = new MD5CryptoServiceProvider();
            System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
            Byte[] BytesMessage = ASCII.GetBytes(text);

            byte[] array = hash.ComputeHash(BytesMessage);

            return BitConverter.ToString(array);
        }

        public static string GenerateRadomText(int size)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[size];
            Random rd = new Random();

            chars[0] = 'a';
            chars[1] = '9';

            for (int i = 2; i < size; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
