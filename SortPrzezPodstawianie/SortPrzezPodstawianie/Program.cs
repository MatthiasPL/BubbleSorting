using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortPrzezPodstawianie
{
    class Program
    {
        public static int[] tosort = new int[1];
        public static List<int> array = new List<int>();
        public static List<int> indexes = new List<int>();
        public static long steps = 0;
        public static int step = 0;
        public static int mainstep = 0;

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for (int j = 0; j < 60; j++) {
                numbers.Clear();
                for (int i = 0; i < 500*j; i++)
                {
                    numbers.Add(rnd.Next(0, 1000000));
                }

                int[] newarray = numbers.ToArray();
                Array.Resize(ref tosort, newarray.Count());
                tosort = newarray;

                array = tosort.ToList();

                for (int i = 0; i < array.Count(); i++)
                {
                    indexes.Add(i);
                }

                var watch1 = System.Diagnostics.Stopwatch.StartNew();

                for (int i = tosort.Count() - 1; i > 0; i--)
                {
                    if (array.Count() != 0)
                    {
                        FindMaximalValue();
                        int temp = tosort[array.Count() - 1];
                        tosort[array.Count() - 1] = tosort[indexes[0]];
                        tosort[indexes[0]] = temp;
                        ResetIndexes();
                        mainstep++;
                    }

                    
                    if (array.Count > 0)
                    {
                        ShortenArray();
                    }
                }

                watch1.Stop();
                var elapsedMs1 = watch1.ElapsedMilliseconds;
                using (StreamWriter w = File.AppendText("data1.txt"))
                {
                    //Nothing to do
                    w.WriteLine(numbers.Count() + " " + elapsedMs1);
                }
                Console.WriteLine("done");
            }

            Console.WriteLine("done all");
            Console.ReadKey();
        }

        public static void ShortenArray()
        {
            array.Clear();
            for(int i = 0; i < tosort.Count()-mainstep; i++)
            {
                array.Add(tosort[i]);
            }
        }

        private static void ResetIndexes()
        {
            for (int i = 0; i < array.Count(); i++)
            {
                indexes[i]=i;
            }
        }

        private static void Initialize()
        {
            for(int i =0; i < array.Count(); i++)
            {
                indexes.Add(i);
            }
        }

        private static void FindMaximalValue()
        {
            steps = (long)Math.Ceiling(Math.Log(array.Count(), 2));

            for(step = 1; step <= steps; step++)
            {
                //Parallel.For(0, (int)Math.Ceiling(Math.Log(2, array.Count()))+50, CompareSwap);
                Parallel.For(0, (int)array.Count()+(int)Math.Pow(2, step), CompareSwap);
            }
        }

        private static void CompareSwap(int i)
        {
            int index1 = i * (int)Math.Pow(2, step);
            int index2 = (int)Math.Pow(2, step - 1) + i * (int)Math.Pow(2, step);

            if (index2<array.Count())
            {
                if (array[index1] > array[index2])
                {
                    //Nothing to do
                }
                else
                {
                    int temp = array[index1];
                    array[index1] = array[index2];
                    array[index2] = temp;

                    int tempindex = index1;
                    indexes[index1] = indexes[index2];
                    indexes[index2] = tempindex;
                }
            }
        }
    }
}
