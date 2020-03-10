using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallel
{
    class FileService
    {
        public void ReadFileSync() {
            List<Task> tasks = new List<Task>();
            string line;
            int counter = 0;
            System.IO.StreamReader file = new System.IO.StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                tasks.Add(ProcessLineNewTask(line));
                counter++;
            }

            Task.WaitAll(tasks.ToArray());
            file.Close();

        }

        public async void ReadFileAsync() {
            var sw = Stopwatch.StartNew();
            sw.Start();
            List<Task> tasks = new List<Task>();
            string line;
            int counter = 0;
            StreamReader file = new StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            while ((line = await file.ReadLineAsync()) != null)
            {
                System.Console.WriteLine(line);
                //tasks.Add(ProcessLineNewTask(line));
                //ProcessLine();
                counter++;
            }
            Task.WaitAll(tasks.ToArray());
            file.Close();
            sw.Stop();
            Console.WriteLine($"{nameof(FileService.ReadFileAsync)} {sw.ElapsedMilliseconds}ms");
        }

        void ProcessLine(string str)
        {
            Thread.Sleep(100);
        }

        Task ProcessLineNewTask(string str)
        {
            return Task.Delay(100);
        }

        
    }
}
