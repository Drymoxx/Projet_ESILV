using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Classe représentant une liste de lettres utilisées dans le jeu
//Charge les lettres à partir d'un fichier texte et les stocke dans une liste

namespace projet
{
    class Liste_Lettre
    {
        //Attributs
        private List<Lettre> liste;

        //Constructeur
        public Liste_Lettre()
        {
            liste = new List<Lettre>();

            using (StreamReader a = new StreamReader("Lettre.txt"))
            {
                string? line;
                while ((line = a.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    liste.Add(new Lettre(line));
                }
            }
        }

        //Propriétés
        
        public List<Lettre> Liste
        {
            get { return liste; }
            set { liste = value; }
        }
    }
}