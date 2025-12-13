using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet
{
    class Jeu
    {
        private Plateau plateau;
        private Dictionnaire dictionnaire;
        private Joueur j1;
        private Joueur j2;
        public Jeu(Joueur j1, Joueur j2, string nameFile)
        {
            this.j1 = j1;
            this.j2 = j2;
            this.plateau = new Plateau(nameFile);
            Dictionnaire dico = new Dictionnaire();
            dico.Tri_Fusion();
            this.dictionnaire = dico;
        }
        public Jeu(Joueur j1, Joueur j2, int taille)
        {
            this.j1 = j1;
            this.j2 = j2;
            this.plateau = new Plateau(taille);
            Dictionnaire dico = new Dictionnaire();
            dico.Tri_Fusion();
            this.dictionnaire = dico;
        }
        
    }
}