using System;
using System.IO;
using System.Collections.Generic;

namespace projet
{
    class Lettre
    {
        private char nom;
        private int occurence;
        private int poids;
        public Lettre(string a)
        {
            a = a.Trim();
            string[] info = a.Split(',');
            nom = char.Parse(info[0]);
            occurence = int.Parse(info[1]);
            poids = int.Parse(info[2]);
        }
        public char Nom
        {
            get { return nom; }
        }
        public int Poids
        {
            get { return poids; }
        }
        public int Occurence
        {
            get { return occurence; }
            set { occurence = value; }
        }
    }
}