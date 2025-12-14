using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace projet
{
    class Jeu
    {
        private Plateau plateau;
        private Dictionnaire dictionnaire;
        private Joueur j1;
        private Joueur j2;
        private Joueur joueurCourant;
        private int tempsParTour; 
        private TimeSpan tempsTotal;
        private DateTime debutPartie;
        public Jeu(Joueur j1, Joueur j2, string nameFile, int tempspartie, int tempsParTour)
        {
            this.j1 = j1;
            this.j2 = j2;
            this.plateau = new Plateau(nameFile);
            Dictionnaire dico = new Dictionnaire();
            dico.Tri_Fusion();
            this.dictionnaire = dico;
            this.tempsParTour = tempsParTour;
            tempsTotal = TimeSpan.FromSeconds(tempspartie);
            joueurCourant = j1;
        }
        public Jeu(Joueur j1, Joueur j2, int taille, int tempspartie, int tempsParTour)
        {
            this.j1 = j1;
            this.j2 = j2;
            this.plateau = new Plateau(taille);
            Dictionnaire dico = new Dictionnaire();
            dico.Tri_Fusion();
            this.dictionnaire = dico;
            this.tempsParTour = tempsParTour;
            tempsTotal = TimeSpan.FromSeconds(tempspartie);
            joueurCourant = j1;
        }
      
        /*public void LancerPartie()
        {
            debutPartie = DateTime.Now;

            while (!PartieTerminee())
            {
                TourJoueur();
                ChangerJoueur();
            }

            FinPartie();
        }*/

        private void TourJoueur()
        {
            DateTime debutTour = DateTime.Now;
            DateTime finTour = debutTour.AddSeconds(tempsParTour);
            while (DateTime.Now < finTour && !plateau.EstVide())
            {
                Console.Clear();
                Console.WriteLine(plateau);
                Console.Write("Mot : ");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (dictionnaire.RechDichoRecursif(key.KeyChar.ToString()) && plateau.MotsEstPresent(key.KeyChar.ToString()))
                    {
                        plateau.Maj_Plateau(key.KeyChar.ToString());
                        List<Lettre> new_mot = StringToLettre(key.KeyChar.ToString());
                        for (int i = 0; i < new_mot.Count; i++)
                        {
                            joueurCourant.Add_Score(new_mot[i].Poids);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mot invalide");
                        Thread.Sleep(800);
                    }
                }
            }
        }
        private List<Lettre> StringToLettre(string mot)
        {
            mot = mot.ToUpper();
            Liste_Lettre liste = new Liste_Lettre();
            List<Lettre> new_mot = new List<Lettre>();
            for (int i = 0; i < mot.Length; i++)
            {
                switch(mot[i])
                {
                    case 'A':
                        new_mot.Add(liste.Liste[0]);
                        break;
                    case 'B':
                        new_mot.Add(liste.Liste[1]);
                        break;
                    case 'C':
                        new_mot.Add(liste.Liste[2]);
                        break;
                    case 'D':
                        new_mot.Add(liste.Liste[3]);
                        break;
                    case 'E':
                        new_mot.Add(liste.Liste[4]);
                        break;
                    case 'F':
                        new_mot.Add(liste.Liste[5]);
                        break;
                    case 'G':
                        new_mot.Add(liste.Liste[6]);
                        break;
                    case 'H':
                        new_mot.Add(liste.Liste[7]);
                        break;
                    case 'I':
                        new_mot.Add(liste.Liste[8]);
                        break;
                    case 'J':
                        new_mot.Add(liste.Liste[9]);
                        break;
                    case 'K':
                        new_mot.Add(liste.Liste[10]);
                        break;
                    case 'L':
                        new_mot.Add(liste.Liste[11]);
                        break;
                    case 'M':
                        new_mot.Add(liste.Liste[12]);
                        break;
                    case 'N':
                        new_mot.Add(liste.Liste[13]);
                        break;
                    case 'O':
                        new_mot.Add(liste.Liste[14]);
                        break;
                    case 'P':
                        new_mot.Add(liste.Liste[15]);
                        break;
                    case 'Q':
                        new_mot.Add(liste.Liste[16]);
                        break;
                    case 'R':
                        new_mot.Add(liste.Liste[17]);  
                        break;
                    case 'S':
                        new_mot.Add(liste.Liste[18]);
                        break;
                    case 'T':
                        new_mot.Add(liste.Liste[19]);
                        break;
                    case 'U':
                        new_mot.Add(liste.Liste[20]);
                        break;
                    case 'V':
                        new_mot.Add(liste.Liste[21]);
                        break;
                    case 'W':
                        new_mot.Add(liste.Liste[22]);
                        break;
                    case 'X':
                        new_mot.Add(liste.Liste[23]);
                        break;
                    case 'Y':
                        new_mot.Add(liste.Liste[24]);
                        break;
                    case 'Z':
                        new_mot.Add(liste.Liste[25]);
                        break;
                    default:
                        break;
                }
            }
            return new_mot;
        }
        public bool PartieTerminee()
        {
            if(plateau.EstVide() || tempsTotal.TotalSeconds <= 0) return true;
            return false;
        }
    }
}