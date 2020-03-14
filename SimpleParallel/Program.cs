using System;
using System.Diagnostics;

namespace SimpleParallel
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Parallel");

            Console.WriteLine("The number of processors " +
        "on this computer is {0}.",
        Environment.ProcessorCount);

            //MetricsService ms = new MetricsService();
            //ms.Collect(new FileService().ReadFileProcessLineSync);

            //new FileService().ReadFileProcessLineAsync();

            new FileService().ReadFileSyncProcessLineMultileTask();

            //new FileService().ReadFileAsyncAndProcessLineMultipleTask();

            //MetricsService ms2 = new MetricsService();
            //string str = "The thread 0x1124 has exited with code 0";
            //ms2.Collect(() => str.EndsWith('a'));

            //ms2.Collect(() => str.Replace('a','b'));
            //ms2.Collect(() => str.Split(" "));

            Console.ReadLine();
        }

        
    }
}
