using System;
using System.Threading;

namespace ApplyingAsynchronousProgramming
{
    public class DebugHelper
    {
        public static void WriteCurrentThread()
        {
            Console.WriteLine($"CurrentThread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void WriteWorkerThreadsAvailable()
        {
            ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            Console.WriteLine($"workerThreadsAvailable: {workerThreads}");
        }
    }
}
