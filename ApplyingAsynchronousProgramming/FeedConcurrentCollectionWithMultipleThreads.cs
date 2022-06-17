using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    /// Use concurrent collections like ConcurrentBag for writing
    /// data from different threads.
    /// </summary>
    public class FeedConcurrentCollectionWithMultipleThreads
    {
        public async static void RunExample()
        {
            var numbers = new ConcurrentBag<int>();

            var task1 = Task.Run(() => {
                int i = 0;
                while (i < 3)
                {
                    numbers.Add(i);
                    i++;
                }
            });

            var task2 = Task.Run(() => {
                int i = 3;
                while (i < 6)
                {
                    numbers.Add(i);
                    i++;
                }
            });

            var task3 = Task.Run(() => {
                int i = 6;
                while (i < 10)
                {
                    numbers.Add(i);
                    i++;
                }
            });

            await Task.WhenAll(task1, task2, task3);

            foreach (var number in numbers)
                Console.WriteLine(number);

            Console.ReadLine();
        }
    }
}
