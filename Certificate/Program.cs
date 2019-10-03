using Certificate.Chapter2.Examples.AttributeExample;
using Certificate.Chapter2.Examples.ClassExample;
using Certificate.Chapter2.Examples.CodeDomExamples;
using Certificate.Chapter2.Examples.DynamicTypeExample;
using Certificate.Chapter2.Examples.EnumExample;
using Certificate.Chapter2.Examples.GCExamples;
using Certificate.Chapter2.Examples.ImplementingInterfaces;
using Certificate.Chapter2.Examples.StringExample;
using Certificate.Chapter2.Examples.ValueReferenceTypes;
using Certificate.Chapter3.Examples.SecureStringExample;
using Certificate.Chapter4.Examples.IOExample;
using Certificate.Chapter4.Examples.LinqExample;
using Certificate.Chapter4.Examples.XmlExample;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqQuery linqQuery = new LinqQuery();
            linqQuery.LinqToXml();
            Console.ReadLine();
        }
    }
}
