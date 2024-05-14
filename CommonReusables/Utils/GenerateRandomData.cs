using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.CommonReusables.Utils
{
    public class GenerateRandomData
    {
        private static Random random = new Random();
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

       
        public static string GenerateRandomText()
        {
            int length = 6;
            char[] name = new char[length];
            for (int i = 0; i < length; i++)
                name[i] = Alphabet[random.Next(Alphabet.Length)];
            return new string(name)+ "QATEST";
        }
        public static string GenerateRandomZip()
        {
            const int zipLength = 6;
            string zip = "";
            for (int i = 0; i < zipLength; i++)
            {
                zip += random.Next(10);
            }
            return zip;
        }
    }
}
