using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    public interface IEntity
    {
        int Id { get; }
    }

    public class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(x => x.Id == id);
        }
    }
}
