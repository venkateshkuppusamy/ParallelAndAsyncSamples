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
            //Colors.PrintColors();
            // Numbers.Print();

            //MetricsService ms = new MetricsService();
            //Numbers num = new Numbers();
            //ms.Collect(num.FindNumberDivisorsSequential);
            //ms.Collect(num.FindNumberDivisorsParallel);

            MetricsService ms = new MetricsService();
            ms.Collect(new FileService().ReadFileSync);

            new FileService().ReadFileAsync();
            Console.ReadLine();
        }

        
    }
}
