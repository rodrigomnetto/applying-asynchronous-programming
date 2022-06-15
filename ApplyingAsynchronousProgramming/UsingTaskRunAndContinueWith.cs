using System;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    /// Instead of using Async/Await (await Task.Run) is also possible to use
    /// ContinueWith to execute the continuation of an asynchronous code. In this
    /// way the line "end of principal execution" will execute before the line "end task".
    /// </summary>
    public class UsingTaskRunAndContinueWith
    {
        public static void RunExample()
        {
            Task.Run(async () => {

                Console.WriteLine("begin task");
                DebugHelper.WriteCurrentThread();
                await Task.Delay(3000);

                return "example";
            }).ContinueWith(
                (task) => {
                    Console.WriteLine($"\n end {task.Result} task"); //task.Result doesn't block the thread because the async operation has finished.
                    DebugHelper.WriteCurrentThread();
                },
                TaskContinuationOptions.OnlyOnRanToCompletion //only executes when the task succesfully executed. For error treatment use OnlyOnFaulted
            );

            Console.WriteLine("end of principal execution");
        }
    }
}
