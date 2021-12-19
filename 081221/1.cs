using System;
using System.Collections.Generic;
using System.Text;

namespace Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            PrimeFactors f = new PrimeFactors();
            string div = f.GetFactors(n);
            Console.WriteLine(div);
            Console.ReadLine();
        }
    }
}
