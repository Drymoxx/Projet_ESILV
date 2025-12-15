using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

//Classe principale gérant le déroulement d'une partie

namespace projet
{
    class Jeu
    {
        //Attributs
        private Plateau plateau;
        private Dictionnaire dictionnaire;
        private Joueur j1;
        private Joueur j2;
        private Joueur joueurCourant;
        private int tempsParTour; 
        private TimeSpan tempsTotal;
        private int tempsPartieSecondes;
        private DateTime debutPartie;

        //Constructeurs
        public Jeu(Joueur j1, Joueur j2, string nameFile, int tempspartie, int tempsParTour)
        {
            this.tempsPartieSecondes = tempspartie;
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
            this.tempsPartieSecondes = tempspartie;
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

        //Méthodes

        //Lance la partie et gère le déroulement des tours
        public void LancerPartie()
        {
            debutPartie = DateTime.Now;
            while (!PartieTerminee())
            {
                TourJoueur();
                ChangerJoueur();
            }
        }

        //Change le joueur courant à la fin d'un tour
        public void ChangerJoueur()
        {
            if (joueurCourant == j1)
            {
                joueurCourant = j2;
            }
            else
            {
                joueurCourant = j1;
            }
        }

        //Gère le tour d'un joueur avec la saisie de mots et le chronomètre
        private void TourJoueur()
        {
            DateTime debutTour = DateTime.Now;
            DateTime finTour = debutTour.AddSeconds(tempsParTour);
            string mot = "";
            while (DateTime.Now < finTour && !plateau.EstVide())
            {

                Console.Clear();
                Console.WriteLine(plateau);
                Console.WriteLine($"Joueur : {joueurCourant.Nom} | Score : {joueurCourant.Score}");
                int restant = tempsPartieSecondes - (int)(DateTime.Now - debutPartie).TotalSeconds;
                if (restant < 0) restant = 0;
                
                Console.WriteLine($"Temps restant (partie) : {restant}s | Temps restant (tour) : {(int)(finTour - DateTime.Now).TotalSeconds}s");
                Console.Write("Mot : " + mot);

                if (Console.KeyAvailable)
                {
                    var touche = Console.ReadKey(intercept:true);

                    if (touche.Key == ConsoleKey.Enter)
                    {
                        string motSaisi = mot.Trim().ToUpper();
                        mot = "";

                        if (motSaisi.Length < 2)
                        {
                            Console.WriteLine("\nMot trop court.");
                            System.Threading.Thread.Sleep(700);
                            continue;
                        }

                        if (joueurCourant.Mots != null && joueurCourant.Contient(motSaisi))
                        {
                            Console.WriteLine("\nDéjà trouvé !");
                            System.Threading.Thread.Sleep(700);
                            continue;
                        }

                        if (!plateau.MotsEstPresent(motSaisi))
                        {
                            Console.WriteLine("\nPas sur le plateau.");
                            System.Threading.Thread.Sleep(700);
                            continue;
                        }

                        if (!dictionnaire.RechDichoRecursif(motSaisi))
                        {
                            Console.WriteLine("\nPas dans le dictionnaire.");
                            System.Threading.Thread.Sleep(700);
                            continue;
                        }

                        plateau.Maj_Plateau(motSaisi);

                        int score = 0;
                        foreach (Lettre l in StringToLettre(motSaisi))
                            score += l.Poids;

                        joueurCourant.Add_Score(score);

                        if (joueurCourant.Mots == null) joueurCourant.Mots = new List<string>();
                        joueurCourant.Mots.Add(motSaisi);

                        Console.WriteLine($"\nMot valide ! (+{score})");
                        System.Threading.Thread.Sleep(900);
                        break; 
                    }
                    else if (touche.Key == ConsoleKey.Backspace )
                    {
                        if(mot.Length > 0)
                            mot = mot.Substring(0, mot.Length - 1);
                    }
                    else
                    {
                        if(char.IsLetter(touche.KeyChar))
                            mot += touche.KeyChar;
                    }
                }
                System.Threading.Thread.Sleep(10); 
                
            }
        }

        //Convertit une chaîne de caractères en une liste de lettres

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

        //Vérifie si la partie est terminée (temps écoulé ou plateau vide)
        public bool PartieTerminee()
        {
            TimeSpan ecoule = DateTime.Now - debutPartie;
            if (plateau.EstVide() || ecoule.TotalSeconds >= tempsPartieSecondes) return true;
            return false;
        }
    }
}