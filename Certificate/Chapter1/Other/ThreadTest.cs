using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter1.Other
{
    public class ThreadTest
    {
        public static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write(" y");
        }
    }
}
