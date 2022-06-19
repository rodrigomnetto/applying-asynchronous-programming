using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    public class WorkingWithAttachedTasks
    {

        /// <summary>
        /// by default task.run doesn't allow attached tasks, so you have
        /// to use task factory for it. Task factory gives more flexibility,
        /// actually Task.Run uses Task.Factory under the hood.
        /// </summary>
        public async static void RunExample()
        {
            await Task.Factory.StartNew(() =>
            {
                Task.Factory.StartNew(() => {
                    Thread.Sleep(2000); //block's the thread pool thread
                    Console.WriteLine("completed 1");
                
                }, TaskCreationOptions.AttachedToParent);
                //The child task is attached to its parent, which means that even using the await keyword,
                //the execution of the parent thread will only finish when the execution of the child thread ends.
            });
            Console.WriteLine("completed");
        }
    }
}
