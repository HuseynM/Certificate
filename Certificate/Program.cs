using Certificate.Chapter2.Examples.AttributeExample;
using Certificate.Chapter2.Examples.ClassExample;
using Certificate.Chapter2.Examples.CodeDomExamples;
using Certificate.Chapter2.Examples.CryptographyExample;
using Certificate.Chapter2.Examples.DynamicTypeExample;
using Certificate.Chapter2.Examples.EnumExample;
using Certificate.Chapter2.Examples.GCExamples;
using Certificate.Chapter2.Examples.HashingExample;
using Certificate.Chapter2.Examples.ImplementingInterfaces;
using Certificate.Chapter2.Examples.StringExample;
using Certificate.Chapter2.Examples.ValueReferenceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<string> set = new Set<string>();
            set.Insert("a");
            set.Insert("b");
            var a = set.Contains("b");
            Console.ReadLine();
        }
    }
}
