using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.Encapsulation
{
    public class ExplicitInterface
    {
        public void Execute()
        {
            DbContext ctx = new DbContext("");
            var objectContext = ((IObjectContextAdapter)ctx).ObjectContext;
        }
    }

    public interface ILeft
    {
        void Move();
    }
    public interface IRight
    {
        void Move();
    }

    public class Movement : ILeft, IRight
    {
        void ILeft.Move() { }
        void IRight.Move() { }

    }
}
