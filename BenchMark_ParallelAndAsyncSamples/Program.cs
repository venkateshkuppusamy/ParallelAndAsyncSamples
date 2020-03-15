using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using SimpleParallel;
using System;
using System.Threading;

namespace BenchMark_ParallelAndAsyncSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var summary = BenchmarkRunner.Run<BenchMarkFileService>();
        }
    }

    [SimpleJob(launchCount: 1, warmupCount: 2, targetCount: 5)]
    public class BenchMarkFileService {

        //[Benchmark]
        public void ReadFileSync()
        {
            FileService fs = new FileService();
            fs.ReadFileProcessLineSync();
        }

        //[Benchmark]
        public void ReadFileProcessLineAsync()
        {
            FileService fs = new FileService();
            fs.ReadFileProcessLineAsync();
        }

        //[Benchmark]
        public void ReadFileSyncProcessLineMultileTask()
        {
            FileService fs = new FileService();
            fs.ReadFileSyncProcessLineMultileTask();
        }

        //[Benchmark]
        public void ReadFileAsyncAndProcessLineMultipleTask()
        {
            FileService fs = new FileService();
            fs.ReadFileAsyncAndProcessLineMultipleTask();
        }

        [Benchmark]
        public void ReadFileAllLinesAndProcessSequ()
        {
            FileService fs = new FileService();
            fs.ReadFileAllLinesAndProcessSequ();
        }

        //[Benchmark]
        public void ReadFileAllLinesAndProcessParallel()
        {
            FileService fs = new FileService();
            fs.ReadFileAllLinesAndProcessParallel();
        }

    }
}
