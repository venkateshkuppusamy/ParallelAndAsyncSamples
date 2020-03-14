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
        public void ReadFileProcessLineSync()
        {
            string line;
            int counter = 0;
            StreamReader file = new StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            while ((line = file.ReadLine()) != null)
            {
                ProcessLine(line);
                counter++;
            }
            file.Close();
        }

        public void ReadFileSyncProcessLineMultileTask() {

            var sw = Stopwatch.StartNew();
            sw.Start();

            List<Task<int>> tasks = new List<Task<int>>();
            string line;
            int counter = 0;
            StreamReader file = new StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(100))
            {
                while ((line = file.ReadLine()) != null)
                {
                    tasks.Add(ProcessLineNewTask(line, concurrencySemaphore));
                    counter++;
                }
            }
            Task.WaitAll(tasks.ToArray());
            int result = 0;
            foreach (var item in tasks)
            {
                result = result + item.Result;
            }
            Console.WriteLine(result);
            file.Close();
            sw.Stop();
            Console.WriteLine($"{nameof(FileService.ReadFileSyncProcessLineMultileTask)} {sw.ElapsedMilliseconds}ms");

        }

        public async void ReadFileProcessLineAsync()
        {
            var sw = Stopwatch.StartNew();
            sw.Start();
            string line;
            int counter = 0;
            StreamReader file = new StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            while ((line = await file.ReadLineAsync()) != null)
            {
                ProcessLine(line);
                counter++;
            }
            file.Close();
            sw.Stop();
            Console.WriteLine($"{nameof(FileService.ReadFileProcessLineAsync)} {sw.ElapsedMilliseconds}ms");
        }


        public async void ReadFileAsyncAndProcessLineMultipleTask() {
            var sw = Stopwatch.StartNew();
            sw.Start();
            List<Task<int>> tasks = new List<Task<int>>();
            string line;
            long counter = 0;
            StreamReader file = new StreamReader($@"{Directory.GetCurrentDirectory()}\Files\Sample.txt");
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(100))
            {
                while ((line = await file.ReadLineAsync()) != null)
                {
                    concurrencySemaphore.Wait();
                    tasks.Add(ProcessLineNewTask(line,concurrencySemaphore));
                    counter++;
                }
            }
            Task.WaitAll(tasks.ToArray());
            long result = 0;
            foreach (var item in tasks)
            {
                result = result + item.Result;
            }
            Console.WriteLine(result);
            file.Close();
            sw.Stop();
            Console.WriteLine($"{nameof(FileService.ReadFileAsyncAndProcessLineMultipleTask)} {sw.ElapsedMilliseconds}ms");
        }

        void ProcessLine(string str)
        {
            for (int i = 0; i < 100000; i++)
            {

            }
            
        }
        static int counter =0;
        Task<int> ProcessLineNewTask(string str, SemaphoreSlim concurrencySemaphore)
        {
            var task = Task.Run(() =>
            {
                int counter = 0;
                for (int i = 0; i < 100000; i++)
                {
                    counter++;
                }
                return counter;
            });
            
            //var task = Task.Run(() => { string[] strArray = str.Split(" "); str.Insert(0, "start");  });
            concurrencySemaphore.Release();
            return task;
        }

        Task ProcessLineNewTask(string str)
        {

            var task = Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {

                }
            });
            //var task = Task.Run(() => { string[] strArray = str.Split(" "); str.Insert(0, "start"); });
            return task;
        }

    }
}
