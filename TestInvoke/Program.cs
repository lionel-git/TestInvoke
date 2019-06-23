using System;
using System.Runtime.InteropServices;

namespace TestInvoke
{
    class Program
    {
        [DllImport("Calculator.dll")]
        public static extern double do_sum(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(do_sum(2.0,3.0));
        }
    }
}
