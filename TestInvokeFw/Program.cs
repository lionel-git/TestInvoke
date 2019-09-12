using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace TestInvoke
{
    class Program
    {
        [DllImport("Calculator.dll")]
        public static extern double do_sum(double a, double b);

        //[DllImport("SubLibrary.dll")]
        //public static extern double do_sum(double a, double b);

        static void TestSync()
        {
            var e = new CountdownEvent(2);
            e.Signal(2);
            bool ret = e.Wait(2000);
            Console.WriteLine(ret);
        }

        static void TestSync2()
        {
            var e = new ManualResetEvent(false);
            Task.Run(() => { Thread.Sleep(800); e.Set(); });
            bool ret = e.WaitOne(1000);
            Console.WriteLine(ret);
            bool ret2 = e.WaitOne(1000);
            Console.WriteLine(ret2);
        }

        [HandleProcessCorruptedStateExceptions]
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Hello World!");
                //TestSync2(); return;


                Console.WriteLine("Start");
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
                Console.WriteLine($"Ex: {e}");
            }
            finally
            {
                Console.WriteLine("End");
            }
        }
    }
}
