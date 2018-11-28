using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortPrzezPodstawianie
{
    class SortowanieJednowatkowe
    {
        public SortowanieJednowatkowe() { }

        public void Sortuj(int[] arr)
        {
            //var watch = System.Diagnostics.Stopwatch.StartNew();

            int[] sortedarr = new int[arr.Length];
            while (arr.Length != 0)
            {
                int maxValue = arr.Max();
                int maxIndex = arr.ToList().IndexOf(maxValue);
                int lastIndex = arr.Length - 1;
                int lastValue = arr[lastIndex];
                sortedarr[lastIndex] = maxValue;
                arr[maxIndex] = lastValue;
                Array.Resize(ref arr, arr.Length - 1);
            }

            /*for (int i = 0; i < sortedarr.Length; i++)
                Console.WriteLine(sortedarr[i]);
            // to mozna pozniej usunac, tylko ze dla tak malej ilosci danych bez wypisywania i tak jest 0ms...
            // trzeby by³o w takim razie zrobiæ jeszcze losowanie pierdyliarda liczb zeby sobie to powoli robil
            // P.S. nie zapomnij pozniej usunac tych moich komentarzy xd

            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;

            //Console.WriteLine("Sortowanie jednow¹tkowe: " + elapsedMs + " ms");

            Console.ReadKey();*/
        }
    }
}
