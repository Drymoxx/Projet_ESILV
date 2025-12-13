using System;
using System.IO;
using System.Collections.Generic;

namespace projet
{
    class Program
    {
        static void Main(string[] args)
        {
            int duree = 10;
            DateTime fin = DateTime.Now.AddSeconds(duree);

            while (DateTime.Now < fin)
            {
                TimeSpan restant = fin - DateTime.Now;
                Console.Clear();
                Console.WriteLine($"Temps restant : {restant.Seconds} s");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Temps écoulé !");
        }
    }
}