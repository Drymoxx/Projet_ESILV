using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Classe représentant un joueur dans le jeu
//Gère les informations du joueur telles que le nom, les mots trouvés et le score
//Fournit des méthodes pour ajouter des mots, afficher les mots trouvés et gérer le score

namespace projet
{
    class Joueur
    {
        //Attributs
        private string nom;
        private List<string> mots;
        private int score;

        //Constructeur
        public Joueur(string nom)
        {
            this.nom = nom;
            mots = new List<string>();
            score = 0;
        }

        //Propriétés 
        public string Nom
        {
            get{return nom;}
        }
        public List<string> Mots
        {
            get{return mots;}
            set{mots = value;}
        }
        public int Score
        {
            get{return score;}
            set{score = value;}
        }

        //Méthodes

        //Ajoute un mot à la liste des mots trouvés par le joueur
        public void Add_Mot(string a)
        {
            mots.Add(a);
        }

        //Retourne une chaîne de caractères affichant tous les mots trouvés par le joueur
        public string affichermot()
        {
            string a = "";
            for(int i = 0; i < mots.Count; i++)
            {
                a = a + mots[i] + "; ";
            }
            return a;
        }

        //Retourne un affichage textuelle du joueur avec son nom, son score et les mots trouvés
        public override string ToString()
        {
            return $"Le joueurs {nom} a {score} de score est a trouvé les mots suivant : {affichermot()}";
        }

        //Ajoute une valeur au score du joueur
        public void Add_Score(int val)
        {
            score = score + val;
        }

        //Vérifie si le joueur a déjà trouvé un mot donné
        public bool Contient(string mot)
        {
            bool a = false;
            for(int i = 0; i < mots.Count; i++)
            {
                if(mots[i] == mot)
                {
                    a = true;
                    break;
                }
            }
            return a;
        }
    }
}