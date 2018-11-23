using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortPrzezPodstawianie
{
    class Program
    {
        public static List<int> array = new List<int>{ 3, 5, 2, 1, 6, 7 };
        public static List<int> indexes = new List<int>();
        public static int steps = 0;
        public static int step = 0;

        static void Main(string[] args)
        {
            FindMaximalValue();
            for(int i = 0; i < array.Count(); i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
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
                //Console.WriteLine(step);
                Parallel.For(0, array.Count()/(int)Math.Pow(2, step), CompareSwap);
            }

            indexes.Insert(0, array[0]);
        }

        private static void CompareSwap(int i)
        {
            int index1 = i * (int)Math.Pow(2, step);
            int index2 = 1 + i * (int)Math.Pow(2, step); //tu jest źle

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
                }
            }
        }
    }
}
