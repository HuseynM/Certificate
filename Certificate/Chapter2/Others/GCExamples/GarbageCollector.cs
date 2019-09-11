using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Others.GCExamples
{
    public class GarbageCollector
    {
        public void Execute()
        {
            GarbageCollector gc = new GarbageCollector();
        }
    }
}
