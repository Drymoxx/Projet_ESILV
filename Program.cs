using System;
using System.IO;
using System.Collections.Generic;

namespace projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionnaire dico = new Dictionnaire();
            dico.Tri_Fusion();
            dico.AfficherDictionnaire();
            Console.WriteLine(dico.ToString());
        }
    }
}