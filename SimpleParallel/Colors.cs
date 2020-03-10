using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleParallel
{
    class Colors
    {
        static List<string> colors { get; set; } = new List<string>() { "black", "orange", "green", "yellow", "white", "blue", "dark blue", "navy", "light green", "pink", "rose" };

        public static void PrintColors()
        {
            Console.WriteLine("ForEach Executing...");
            var sw = Stopwatch.StartNew();
            sw.Start();
            foreach (var item in colors)
            {
                Console.WriteLine($"Color: {item}");
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Parallel for Executing...");
            sw.Restart();
            Parallel.ForEach(colors, color => { Console.WriteLine($"Color: {color}"); });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

    }
}
