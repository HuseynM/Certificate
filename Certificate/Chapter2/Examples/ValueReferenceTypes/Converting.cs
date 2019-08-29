using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ValueReferenceTypes
{
    public class Converting
    {
        public void ConvertImplicitly()
        {
            HttpClient client = new HttpClient();
            object o = client;
            IDisposable d = client;
        }

        public void ConvertExplicitly()
        {
            //value type
            double x = 1234.7;
            int a;
            // Cast double to int
            a = (int)x; // a = 1234

            //reference type
            object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;

        }



    }
}
