using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.GCExamples
{
    public class GCTest
    {
        public static void Execute()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("temp.dat");
        }
    }
}
