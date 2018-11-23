using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortPrzezPodstawianie
{
    class Program
    {
        public static int[] tosort = { 1, 2, 3, 4, 5,6,7,8,9,10,11,12,13,14,15,16,17,18,19, 20, 21, 22, 23 };
        public static List<int> array = tosort.ToList();
        public static List<int> indexes = new List<int>();
        public static int steps = 0;
        public static int step = 0;

        static void Main(string[] args)
        {
            for(int i =0; i< array.Count(); i++)
            {
                indexes.Add(i);
            }

            FindMaximalValue();
            for (int i = 0; i < array.Count(); i++)
            {
                Console.WriteLine(indexes[i]);
            }
            ResetIndexes();
            Console.ReadKey();
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
                Parallel.For(0, (int)Math.Ceiling(Math.Log(2, array.Count()))+50, CompareSwap);
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
