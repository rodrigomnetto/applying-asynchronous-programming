using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    /// Use TaskCompletionSource to create awaitables out of legacy
    /// code that don't use the Task Parallel Library (TPL).
    /// </summary>
    public class UsingTaskCompletionSource
    {
        public async static void RunExample()
        {
            /*
             * the method is awaitable even when the operation isn't asynchronous,
             * because we used TaskCompletionSource to return a task.
             * The await will finish and execute the continuation 
             * when the result is set in the task -> task.SetResult(numbers)
             */
            var numbers = await RetrieveNumbersAsync(); 

            Array.ForEach(numbers.ToArray(), number => {
                Console.WriteLine(number);
            });
        }

        private static Task<IEnumerable<int>> RetrieveNumbersAsync()
        {
            var task = new TaskCompletionSource<IEnumerable<int>>(TaskCreationOptions.RunContinuationsAsynchronously);

            ThreadPool.QueueUserWorkItem((_) => {

                var numbers = new List<int>();
                var i = 0;

                while (i <= 10)
                {
                    numbers.Add(i);
                    i++;
                }
                    
                task.SetResult(numbers);
            });

            return task.Task;
        }
    }
}
