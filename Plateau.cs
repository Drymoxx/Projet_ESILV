using System;
using System.IO;
using System.Collections.Generic;
namespace projet
{
    class Plateau
    {
        private int taille;
        private char[,] plateau;

        public Plateau(int taille)
        {
            this.taille = taille;
            plateau = new char[taille, taille];
            InitialiserPlateau();
        }
        public Plateau(string nomFile)
        {
            plateau = new char[taille, taille];
            ToRead(nomFile);
        }
        public void InitialiserPlateau()
        {
            Random r = new Random();
            int a;
            Liste_Lettre liste = new Liste_Lettre();
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    a = r.Next(0, liste.Liste.Count);
                    if(liste.Liste[a].Occurence == 0)
                    {
                        liste.Liste.RemoveAt(a);
                        a = r.Next(0, liste.Liste.Count);
                    }
                    plateau[i, j] = liste.Liste[a].Nom;
                    liste.Liste[a].Occurence--;
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    s += plateau[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }
        public void ToFile(string nomfile)
        {
            using (StreamWriter writer = new StreamWriter(nomfile))
            {
                for (int i = 0; i < taille; i++)
                {
                    writer.Write(plateau[i, 0]);
                    for (int j = 1; j < taille; j++)
                    {
                        writer.Write("," +plateau[i, j]);
                    }
                    writer.WriteLine();
                }
            }
        }
        public void ToRead(string nomfile)
        {
            using (StreamReader reader = new StreamReader(nomfile))
            {
                string? line;
                List<string> tab = new List<string>();
                while ((line = reader.ReadLine()) != null || (line = reader.ReadLine()) != "")
                {
                    tab.Add(line);
                }
                for (int i = 0; i < taille; i++)
                {
                    string[] split = tab[i].Split(',');
                    for (int j = 0; j < taille; j++)
                    {
                        plateau[i, j] = char.Parse(split[j]);
                    }
                }
            }
        }
    }
}