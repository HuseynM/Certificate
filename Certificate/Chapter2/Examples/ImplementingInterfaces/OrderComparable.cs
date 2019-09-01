using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    public class OrderComparable : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            OrderComparable order = obj as OrderComparable;
        }
    }
}
