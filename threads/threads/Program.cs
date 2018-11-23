using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threads
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] arr1 = { 800, 11, 50, 771, 649, 770, 240, 9 };
            int[] arr2 = { 4, 5, 7, 1 };

            string arr1string = "";
            string arr2string = "";

            foreach(int i in arr1)
            {
                arr1string += i.ToString() + ";";
            }
            arr1string=arr1string.Remove(arr1string.Length - 1);

            foreach (int i in arr2)
            {
                arr2string += i.ToString() + ";";
            }
            arr2string=arr2string.Remove(arr2string.Length - 1);

            //Creating the array of handles.
            WaitHandle[] waitHandles = new WaitHandle[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };

            //starting the thread 1
            var thread = new Thread(parameter =>
            {
                BubbleSorting(parameter.ToString());
                //signaling that the thread finished.
                ((AutoResetEvent)waitHandles[0]).Set();
            });

            thread.Start(arr1string);

            //starting the thread 2
            var thread2 = new Thread(parameter =>
            {
                BubbleSorting(parameter.ToString());
                //signaling that the thread finished.
                ((AutoResetEvent)waitHandles[0]).Set();
            });

            thread2.Start(arr2string);

            //waits for all the threads (waitHandles) to call the .Set() method
            //and inform that the execution has finished.
            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine("Done");
            /* continue with the code */
            Console.Read();
        }

        private static void ExecuteSomeCode(string parameter)
        {
            //pretending the execution takes 2 seconds
            Thread.Sleep(2000);

            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread: {0} says {1}", threadId, parameter);
        }

        private static void BubbleSorting(string str)
        {
            int temp = 0;
            int[] arr = str.Split(';').Select(int.Parse).ToArray();

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
        }
    }
}
