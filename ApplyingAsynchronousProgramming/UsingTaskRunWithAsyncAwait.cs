using System;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    /// Task.Run in fact executes code in a different thread (from thread pool) as shown
    /// in the example above.
    /// </summary>
    public class UsingTaskRunWithAsyncAwait
    {
        public static void RunExample()
        {
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();

            Task.Run(async () => {
                Console.WriteLine("\n Begin Task.Run");
                DebugHelper.WriteCurrentThread();
                DebugHelper.WriteWorkerThreadsAvailable();
                
                await Task.Delay(2000);

                Console.WriteLine("\n End Task.Run");
                DebugHelper.WriteCurrentThread();
                DebugHelper.WriteWorkerThreadsAvailable();
            });

            Console.WriteLine("\n Finished principal execution");
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();
        }
    }
}
