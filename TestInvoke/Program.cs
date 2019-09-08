using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TestInvoke
{
    class Program
    {
        [DllImport("Calculator.dll")]
        public static extern double do_sum(double a, double b);

        //[DllImport("SubLibrary.dll")]
        //public static extern double do_sum(double a, double b);

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                var sw = new Stopwatch();
                
                for (int i = 0; i < 10; i++)
                {
                    sw.Restart();
                    var r = do_sum(i, 8.0);
                    double elpased_us = sw.ElapsedTicks * 0.1;
                    Console.WriteLine($"{elpased_us} us ({r})");
                }
                Console.WriteLine("Press key");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
