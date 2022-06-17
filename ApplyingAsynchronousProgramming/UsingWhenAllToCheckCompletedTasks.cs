using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    public class UsingWhenAllToCheckCompletedTasks
    {
        public async static void RunExample()
        {
            var tasks = new List<Task<int>>
            {
                ExecuteTask(1000),
                ExecuteTask(2000),
                ExecuteTask(3000),
                ExecuteTask(4000)
            };

            var firstTaskCompleted = await Task.WhenAny(tasks);

            Console.WriteLine($"first task: {firstTaskCompleted.Result}");

            var completedTasks = await Task.WhenAll(tasks);

            foreach (var task in completedTasks)
                Console.WriteLine($"completed task: {task}");
        }

        private static async Task<int> ExecuteTask(int milliseconds)
        {
            await Task.Delay(milliseconds);
            return milliseconds;
        }
    }
}
