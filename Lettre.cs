using System;
using System.IO;
using System.Collections.Generic;


//Classe représentant une lettre utilisée dans le jeu
//Contient des informations sur le caractère, son occurrence et son poids en points
//Fournit des propriétés pour accéder à ces informations

namespace projet
{
    class Lettre
    {
        //Attributs
        private char nom;
        private int occurence;
        private int poids;

        //Constructeur
        public Lettre(string a)
        {
            a = a.Trim();
            string[] info = a.Split(',');
            nom = char.Parse(info[0]);
            occurence = int.Parse(info[1]);
            poids = int.Parse(info[2]);
        }

        //Propriétés
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