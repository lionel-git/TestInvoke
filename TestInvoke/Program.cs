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
            try
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine(do_sum(7.0, 8.0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
