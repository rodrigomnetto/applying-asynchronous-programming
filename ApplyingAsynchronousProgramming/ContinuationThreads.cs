using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{   
    /// <summary>
    /// This code shows thread pool threads being allocated to execute
    /// the continuation code after the await keyword.
    /// </summary>
    public class ContinuationThreads
    {

        public static void RunExample()
        {
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            Console.WriteLine($"MaxWorkerThreads: {maxWorkerThreads}");
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");

            FryEggs();
            FryBacon();

            Console.WriteLine("\n Finished principal execution");
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");
            WriteWorkerThreadsAvailable();

            Console.ReadLine();
        }

        static async Task FryEggs()
        {
            Console.WriteLine("\n FryEggs begin");
            WriteWorkerThreadsAvailable();
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(3000);

            //continuation code
            Console.WriteLine("\n FryEggs end");
            WriteWorkerThreadsAvailable();
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task FryBacon()
        {
            Console.WriteLine("\n FryBacon begin");
            WriteWorkerThreadsAvailable();
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(2000);

            //continuation code
            Console.WriteLine("\n FryBacon end");
            WriteWorkerThreadsAvailable();
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");
        }

        static void WriteWorkerThreadsAvailable()
        {
            ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            Console.WriteLine($"workerThreadsAvailable: {workerThreads}");
        }
    }
}
