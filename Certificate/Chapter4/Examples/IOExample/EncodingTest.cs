using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter4.Examples.IOExample
{
    public class EncodingTest
    {
        public static void ReadFile()
        {
            using (FileStream fileStream = File.OpenRead(@"D:\Books\test.txt"))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue
            }
        }
    }
}
