using System;
using System.Collections.Generic;
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
        public static int steps = 0;
        public static int step = 0;
        public static int mainstep = 0;

        static void Main(string[] args)
        {
            int[] newarray = { 3, 6, 1, 2, 7, 11, 5, 1, 8, 9, 31, 5, 1, 9, 10, 11, 7, 3, 5, 9, 2, 1, 9, 34, 21, 65, 11, 77, 1, 8, 9, 43, 23 };
            Array.Resize(ref tosort, newarray.Count());
            tosort = newarray;

            array = tosort.ToList();

            for(int i =0; i< array.Count(); i++)
            {
                indexes.Add(i);
            }

            for(int i = tosort.Count()-1; i >= 0; i--)
            {
                FindMaximalValue();

                int temp = tosort[array.Count() - 1];
                tosort[array.Count() - 1] = tosort[indexes[0]];
                tosort[indexes[0]] = temp;
                ResetIndexes();
                mainstep++;
                ShortenArray();
            }

            for (int i = 0; i < tosort.Count(); i++)
            {
                Console.WriteLine(tosort[i]);
            }
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
            steps = (int)Math.Ceiling(Math.Log(array.Count(), 2));

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
