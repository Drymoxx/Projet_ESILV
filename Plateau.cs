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
        public bool MotsEstPresent(string mot)
        {
            List<Coordonnee> chemin = new List<Coordonnee>();
            int derniereLigne = taille - 1;
            for (int j = 0; j < taille; j++)
            {
                if (plateau[derniereLigne, j] == mot[0])
                {
                    bool[,] visite = new bool[taille, taille];
                    if (MotsEstPresentRec(mot, 0, derniereLigne, j, visite, ref chemin)) return true;
                }
            }
            return false;
        }
        private bool MotsEstPresentRec(string mot, int i, int j, int count, bool[,] visite, ref List<Coordonnee> chemin)
        {
            if (i < 0 || i >= taille || j < 0 || j >= taille) return false;
            if (visite[i, j] || plateau[i, j] != mot[count]) return false;
            chemin.Add(new Coordonnee(i, j));
            if (count == mot.Length - 1) return true;
            else
            {
                if (mot[count] == plateau[i, j] && !visite[i, j])
                {
                    visite[i, j] = true;
                    bool trouve =   MotsEstPresentRec(mot, i + 1, j, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i - 1, j, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i, j + 1, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i, j - 1, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i + 1, j + 1, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i - 1, j - 1, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i + 1, j - 1, count + 1, visite, ref chemin) ||
                                    MotsEstPresentRec(mot, i - 1, j + 1, count + 1, visite, ref chemin);
                    if (!trouve) chemin.RemoveAt(chemin.Count - 1);
                    visite[i,j] = false;
                    return trouve;
                }
                else return false;
            }
        }
        public void Maj_Plateau(string mot)
        {
            for(int x = 0; x < taille; x++)
            {
                if(plateau[taille - 1, x] == mot[0])
                {
                    List<Coordonnee> chemin = new List<Coordonnee>();
                    if (MotsEstPresentRec(mot, taille - 1, x, 0, new bool[taille, taille], ref chemin))
                    {
                        foreach (Coordonnee c in chemin)
                        {
                            plateau[c.X, c.Y] = ' ';
                        }
                        return;
                    }
                }
            }
            bool changement;
            do
            {
                changement = false;
                for (int i = taille - 1; i > 0; i--)
                {
                    for (int j = 0; j < taille; j++)
                    {
                        if (plateau[i, j] == ' ' && plateau[i - 1, j] != ' ')
                        {
                            plateau[i, j] = plateau[i - 1, j];
                            plateau[i - 1, j] = ' ';
                            changement = true;
                        }
                    }
                }
            } while (changement);
        }
        public bool EstVide()
        {
            for(int i = 0; i < taille; i++)
            {
                for(int j = 0; j < taille; j++)
                {
                    if(plateau[i, j] != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}