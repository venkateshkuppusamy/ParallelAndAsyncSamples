using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParallel
{
    public class MetricsService
    {
        public static MetricsService Get { get { return new MetricsService(); } }
        
        public void Collect(Action action)
        {
            var sw = Stopwatch.StartNew();
            sw.Start();
            action.Invoke();
            sw.Stop();
            Console.WriteLine($"***************************Method {action.Method.Name}: {sw.Elapsed.TotalMilliseconds}ms **************************");
        }

       
    }
}
