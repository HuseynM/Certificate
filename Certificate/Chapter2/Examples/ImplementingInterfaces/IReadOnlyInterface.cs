using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    public interface IReadOnlyInterface
    {
        int Value { get; }
    }

    public class ReadAndWriteImplementation : IReadOnlyInterface
    {
        public int Value { get; set; }
    }
}
