using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    /// The token passed in task.run will cancel the task only before it starts.
    /// To cancel the running thread you have to check if the token has been canceled or not.
    /// </summary>
    public class UsingTaskRunWithCancellationToken
    {
        public static void RunExample()
        {
            using var cancelationTokenSource = new CancellationTokenSource();
            var token = cancelationTokenSource.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                    await Task.Delay(1000);

                throw new Exception();
            }, token).ContinueWith((task) => Console.WriteLine("task canceled"), TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Cancel task? (y/n):");
            var cancel = Console.ReadLine();

            if (cancel == "y")
                cancelationTokenSource.Cancel();

            Console.ReadLine();
        }
    }
}
