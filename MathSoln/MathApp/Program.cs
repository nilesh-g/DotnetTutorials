using System;
using MathLib;

namespace MathApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMath obj = new MyMath();
            int res1 = obj.Add(22, 7);
            Console.WriteLine("Add Result: " + res1);
            int res2 = obj.Subtract(22, 7);
            Console.WriteLine("Subtract Result: {0}", res2);
        }
    }
}
