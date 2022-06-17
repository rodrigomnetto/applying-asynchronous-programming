using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplyingAsynchronousProgramming
{
    /// <summary>
    ///  each thread in .NET has data associated with it, and that data is usually propagated to new threads. 
    ///  This data includes security information (the IPrinciple and thread identity), 
    ///  the localization strings, and transaction information from System.Transaction. 
    ///  By default, the execution context flows to helper threads.
    ///  <see href="https://www.c-sharpcorner.com/uploadfile/logisimo/a-potentially-helpful-C-Sharp-threading-manual/"/>
    /// </summary>
    public class ExecutionContextSupressFlow
    {
        public static void RunExample()
        {
            var li = new AsyncLocal<int> //Represents ambient data
            {
                Value = 42
            };

            //AsyncLocal is associated to the execution context.
            //The execution context flows to the thread created by Task.Run and ContinueWith
            Task.Run(() =>
            {
                Console.WriteLine("Task.Run: " + li.Value);
            }).ContinueWith(_ =>
            {
                Console.WriteLine("Task.ContinueWith: " + li.Value);
            });

            //If supressed the value 42 is not passed together with the execution context.
            //"li.Value" will return zero in this scenario, because in the context of the new thread
            //the value 42 doesn't exists.
            ExecutionContext.SuppressFlow();
            Task.Run(() =>
            {
                Console.WriteLine("supressed Task.Run: " + li.Value);
            }).ContinueWith(_ =>
            {
                Console.WriteLine("supressed Task.ContinueWith: " + li.Value);
            });

            Console.ReadLine();
            ExecutionContext.RestoreFlow();
        }
    }
}
