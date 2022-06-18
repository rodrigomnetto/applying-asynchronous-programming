using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    public class AsynchronousStream
    {
        public async static void RunExample()
        {
            await foreach (var number in GetAsyncNumbers())
            {
                Console.WriteLine(number);
            }
        }

        private static async IAsyncEnumerable<int> GetAsyncNumbers()
        {
            await Task.Delay(1000); //this block is executed in each iteration of the foreach
            yield return 1;

            await Task.Delay(1000);
            yield return 2;

            await Task.Delay(1000);
            yield return 3;

            await Task.Delay(1000);
            yield return 4;
        }
    }
}
