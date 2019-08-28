using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ExtensionExample
{
    public interface IProduct
    {
        decimal Price { get; set; }
    }
    public class Product : IProduct
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this IProduct product)
        {
            return product.Price * .9M;
        }
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }
}
