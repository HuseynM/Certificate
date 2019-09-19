using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    public interface IAnimal
    {
        void Move();
    }

    public class Dog : IAnimal
    {
        public void Move() { }
        public void Bark() { }
    }
}
