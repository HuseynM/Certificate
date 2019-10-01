using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter4.Examples.LinqExample
{
    public class Lambda
    {
        public void CalculatorAnonymous()
        {
            Func<int, int> myDelegate = delegate (int x)
             {
                 return x * 2;
             };

            Console.WriteLine(myDelegate(21));
        }

        public void CalculatorLambda()
        {
            Func<int, int> myDelegate = x => x * 2;
            Console.WriteLine(myDelegate(21));
        }
    }
}
