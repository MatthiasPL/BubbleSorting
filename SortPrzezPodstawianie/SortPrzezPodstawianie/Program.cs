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
        static void Main(string[] args)
        {
            PodstawienieWielowatkowo wielo = new PodstawienieWielowatkowo();
            SortowanieJednowatkowe jedno = new SortowanieJednowatkowe();

            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for(int j = 0; j <= 60; j ++)
            {
                numbers.Clear();
                for (int i = 0; i < 500*j; i++)
                {
                    numbers.Add(rnd.Next(0, 1000000));
                }

                int[] arr1 = numbers.ToArray();
                int[] arr2 = numbers.ToArray();

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                jedno.Sortuj(arr1);
                watch1.Stop();
                var elapsedMs1 = watch1.ElapsedMilliseconds;
                using (StreamWriter w = File.AppendText("data1.txt"))
                {
                    w.WriteLine(arr1.Length + " " + elapsedMs1);
                }
                Console.WriteLine("done");
            }

            Console.WriteLine("done all");

            Console.ReadKey();
        }
    }
}
