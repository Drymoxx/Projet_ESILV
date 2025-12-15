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
            ToRead(nomFile);
        }
        public void InitialiserPlateau()
        {
            Random r = new Random();
            int a;
            Liste_Lettre liste = new Liste_Lettre();
            List<Lettre> list = new List<Lettre>();
            for (int i = 0; i < 26; i++)
            {
                while(liste.Liste[i].Occurence >= 0)
                {
                    list.Add(liste.Liste[i]);
                    liste.Liste[i].Occurence--;
                }
            }
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    a = r.Next(0, list.Count);
                    plateau[i, j] = list[a].Nom;
                    list.RemoveAt(a);
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
            List<string> lignes = new List<string>();
            using (StreamReader reader = new StreamReader(nomfile))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue; 
                    lignes.Add(line.Trim());
                }
            }

            if(lignes.Count == 0)
            {
                throw new Exception("Fichier vide");
            } 

            taille = lignes.Count;
            plateau = new char[taille, taille];

            for(int i = 0; i < taille; i++)
            {
                string[] split = lignes[i].Split(',');
                if(split.Length != taille)
                {
                    throw new Exception("Format de fichier incorrect");
                }

                for(int j = 0; j < taille; j++)
                {
                    string cell = split[j].Trim();
                    plateau[i,j] = string.IsNullOrEmpty(cell) ? ' ' : cell[0];
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
                    if (MotsEstPresentRec(mot, derniereLigne, j, 0, visite, ref chemin)) return true;
                }
            }
            return false;
        }
        private bool MotsEstPresentRec(string mot, int i, int j, int count, bool[,] visite, ref List<Coordonnee> chemin)
        {
            if (i < 0 || i >= taille || j < 0 || j >= taille) return false;
            if (visite[i, j] || plateau[i, j] != mot[count]) return false;
            visite[i, j] = true;
            chemin.Add(new Coordonnee(i, j));
            if (count == mot.Length - 1) return true;
            else
            {
                bool trouve =   MotsEstPresentRec(mot, i + 1, j, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i - 1, j, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i, j + 1, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i, j - 1, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i + 1, j + 1, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i - 1, j - 1, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i + 1, j - 1, count + 1, visite, ref chemin) ||
                                MotsEstPresentRec(mot, i - 1, j + 1, count + 1, visite, ref chemin);
                if (trouve) return true;
                chemin.RemoveAt(chemin.Count - 1);
                visite[i,j] = false;
                return false;
            }
        }
        public void Maj_Plateau(string mot)
        {
            mot = mot.ToUpper();
            int derniereLigne = taille - 1;

            for(int x = 0; x < taille; x++)
            {
                if(plateau[derniereLigne, x] == mot[0])
                {
                    List<Coordonnee> chemin = new List<Coordonnee>();
                    bool[,] visite = new bool[taille, taille];

                    if (MotsEstPresentRec(mot, derniereLigne, x, 0, visite, ref chemin))
                    {
                        foreach (Coordonnee c in chemin)
                        {
                            plateau[c.X, c.Y] = ' ';
                        }
                        break;
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