using System;
using System.Threading;

namespace ApplyingAsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            Console.WriteLine($"MaxWorkerThreads: {maxWorkerThreads}");

            //AsyncAwaitContinuationThreads.RunExample();
            //UsingTaskRunWithAsyncAwait.RunExample();
            ExecutionContextSupressFlow.RunExample();

            Console.ReadLine();
        }
    }
}
