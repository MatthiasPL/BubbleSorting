using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BubbleSorter
{
    class Program
    {
        static void Main(string[] args)
        {
           // for (int j = 1; j < 4; j++)
           // {
                BubbleSort bs = new BubbleSort();
                List<int> numbers = new List<int>();
                Random rnd = new Random();

                for (int i = 0; i < 5000; i++)
                {
                    numbers.Add(rnd.Next(0, 10000));
                }

            int[] arr = numbers.ToArray();
            //int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };
            var watch = System.Diagnostics.Stopwatch.StartNew();
                //start the bubblesort 

                //Creating the array of handles.
                WaitHandle[] waitHandles = new WaitHandle[]
                {
                    new AutoResetEvent(false),
                    new AutoResetEvent(false)
                };

                //starting the thread 1
                var thread = new Thread(parameter =>
                {
                    bs.BubbleSorting((int[])parameter);
                    //signaling that the thread finished.
                    ((AutoResetEvent)waitHandles[0]).Set();
                });

                thread.Start(arr);

                //starting the thread 2
                var thread2 = new Thread(parameter =>
                {
                    bs.BubbleSorting((int[])parameter);
                    //signaling that the thread finished.
                    ((AutoResetEvent)waitHandles[0]).Set();
                });

                //thread2.Start(arr);

            //waits for all the threads (waitHandles) to call the .Set() method
            //and inform that the execution has finished.
            //Console.WriteLine("aaaa");
            WaitHandle.WaitAll(waitHandles);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine("Number of elements: " + arr.Length + " Time: " + elapsedMs);
           // }

            Console.ReadKey();
        }
    }
}
