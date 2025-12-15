using System;

//Classe représentant une coordonnée sur le plateau de jeu avec des valeurs x et y
//Utilisée pour localiser les positions des lettres et des mots

namespace projet
{
    class Coordonnee
    {
        private int x;
        private int y;

        public Coordonnee(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}