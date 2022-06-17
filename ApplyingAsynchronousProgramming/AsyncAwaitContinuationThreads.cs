using System;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{   
    /// <summary>
    /// This code shows thread pool threads being allocated to execute
    /// the continuation code after the await keyword.
    /// </summary>
    public class AsyncAwaitContinuationThreads
    {

        public static void RunExample()
        {
            DebugHelper.WriteCurrentThread();

            FryEggs();
            FryBacon();

            Console.WriteLine("\n Finished principal execution");
            DebugHelper.WriteWorkerThreadsAvailable();
            DebugHelper.WriteCurrentThread();

            Console.ReadLine();
        }

        static async Task FryEggs()
        {
            Console.WriteLine("\n FryEggs begin");
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();

            await Task.Delay(3000).ConfigureAwait(true);

            //continuation code
            Console.WriteLine("\n FryEggs end");
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();
        }

        static async Task FryBacon()
        {
            Console.WriteLine("\n FryBacon begin");
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();

            await Task.Delay(2000).ConfigureAwait(true);

            //continuation code
            Console.WriteLine("\n FryBacon end");
            DebugHelper.WriteCurrentThread();
            DebugHelper.WriteWorkerThreadsAvailable();
        }
    }
}
