using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Joueur
    {
        private string nom;
        private List<string> mots;
        private int score;
        public Joueur(string nom)
        {
            this.nom = nom;
            mots = new List<string>();
            score = 0;
        }
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
        public void Add_Mot(string a)
        {
            mots.Add(a);
        }
        public string affichermot()
        {
            string a = "";
            for(int i = 0; i < mots.Count; i++)
            {
                a = a + mots[i] + "; ";
            }
            return a;
        }
        public override string ToString()
        {
            return $"Le joueurs {nom} a {score} de score est a trouvé les mots suivant : {affichermot()}";
        }
        public void Add_Score(int val)
        {
            score = score + val;
        }
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