using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SortPrzezPodstawianie
{
    class PodstawienieWielowatkowo
    {
        public static int[] tosort = new int[1];
        public static List<int> array = new List<int>();
        public static List<int> indexes = new List<int>();
        BigInteger steps = new BigInteger(0);
        public static int step = 0;
        public static int mainstep = 0;

        public PodstawienieWielowatkowo() { }

        public void Sortuj(int[] array1)
        {
            int[] newarray = array1;
            Array.Resize(ref tosort, newarray.Count());
            tosort = newarray;
            array = tosort.ToList();
            for (int i = 0; i < array.Count(); i++)
            {
                indexes.Add(i);
            }

            for (int i = tosort.Count() - 1; i >= 0; i--)
            {
                FindMaximalValue();

                int temp = tosort[array.Count() - 1];
                tosort[array.Count() - 1] = tosort[indexes[0]];
                tosort[indexes[0]] = temp;
                ResetIndexes();
                mainstep++;
                ShortenArray();
            }

            /*for (int i = 0; i < tosort.Count(); i++)
            {
                Console.WriteLine(tosort[i]);
            }*/
            //Console.ReadKey();
        }

        public static void ShortenArray()
        {
            array.Clear();
            for (int i = 0; i < tosort.Count() - mainstep; i++)
            {
                array.Add(tosort[i]);
            }
        }

        private static void ResetIndexes()
        {
            for (int i = 0; i < array.Count(); i++)
            {
                indexes[i] = i;
            }
        }

        private static void Initialize()
        {
            for (int i = 0; i < array.Count(); i++)
            {
                indexes.Add(i);
            }
        }

        private void FindMaximalValue()
        {

            //double steppu = Math.Ceiling(Math.Log(array.Count(), 2));
            //if (array.Count() != 0)
            //{
                steps = (BigInteger)Math.Ceiling(Math.Log(array.Count(), 2));
                if (steps < 0)
                {
                    Console.WriteLine(array.Count() + " " + steps);
                }
                //steps = new BigInteger(Math.Ceiling(Math.Log(array.Count(), 2)));

                for (step = 1; step <= steps; step++)
                {
                    //Parallel.For(0, (int)Math.Ceiling(Math.Log(2, array.Count()))+50, CompareSwap);
                    Parallel.For(0, (int)array.Count() + (int)Math.Pow(2, step), CompareSwap);
                }
            //}

        }

        private static void CompareSwap(int i)
        {
            int index1 = i * (int)Math.Pow(2, step);
            int index2 = (int)Math.Pow(2, step - 1) + i * (int)Math.Pow(2, step);

            if (index2 < array.Count())
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
