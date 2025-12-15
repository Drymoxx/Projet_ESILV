using System;
using System.IO;
using System.Collections.Generic;

namespace projet
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== MOTS GLISSES ===");
                Console.WriteLine("1) Nouvelle Partie (plateau aléatoire)");
                Console.WriteLine("2) Nouvelle Partie (plateau depuis un fichier)");
                Console.WriteLine("3) Quitter");
                Console.Write("Choix : ");

                string? choix = Console.ReadLine();

                if (choix == "3") return;

                if(choix!= "1" && choix != "2")
                {
                    Pause("Choix invalide");
                    continue;
                }

                Console.Clear();
                string nom1 = ReadNonEmpty("Nom du joueur 1 : ");
                string nom2 = ReadNonEmpty("Nom du joueur 2 : ");

                Joueur j1 = new Joueur(nom1);
                Joueur j2 = new Joueur(nom2);

                Console.Clear();
                Console.WriteLine("Paramètres de temps (en secondes) :");

                int tempsPartie = ReadIntMin("Durée totale de la partie : ", 10);
                int tempsTour = ReadIntMin("Durée d'un tour : ", 5);

                try
                {
                    Jeu jeu;
                    if(choix == "1")
                    {
                        Console.Clear();
                        int taille = ReadIntMin("Taille du plateau inferieur à 11 (ex : 4, 5, 6...) : ", 2);
                        jeu = new Jeu(j1, j2, taille, tempsPartie, tempsTour);

                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Fichier plateau (CSV : A,B,C,D...) : ");
                        Console.Write("Nom du fichier (ex: plateau.csv) : ");
                        string? file = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
                        {
                            Pause("Fichier invalide");
                            continue;
                        }

                        jeu = new Jeu(j1, j2, file.Trim(), tempsPartie, tempsTour);

                    }

                    Console.Clear();
                    Console.WriteLine("Début de la partie !");
                    Pause("Appuie sur Entrée...");

                    jeu.LancerPartie();

                    Console.Clear();
                    Console.WriteLine("==== FIN DE PARTIE ====");
                    Console.WriteLine($"{j1.Nom} : {j1.Score} points");
                    Console.WriteLine($"{j2.Nom} : {j2.Score} points");

                    if(j1.Score > j2.Score)
                    {
                        Console.WriteLine($"Le gagnant est {j1.Nom} !");
                    }
                    else if (j2.Score > j1.Score)
                    {
                        Console.WriteLine($"Le gagnant est {j2.Nom} !");
                    }
                    else
                    {
                        Console.WriteLine("Egalité !");
                    }
                    
                    Pause("Retour au menu...");
                }
                catch (Exception ex)
                {
                    Pause($"Erreur : {ex.Message}");
                }
            }
        }
        
        static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Appuie sur Entrée pour continuer...");
            Console.ReadLine();
        }

        static string ReadNonEmpty(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string? s  = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(s))
                {
                    return s.Trim();
                }
                Console.WriteLine("Entrée invalide.");
            }
        }

        static int ReadIntMin(string prompt, int min)
        {
            while(true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();

                if (int.TryParse(s, out int val) && val >= min)
                {
                    return val;
                }

                Console.WriteLine("Entrée invalide.");
            }
        }
    }
}