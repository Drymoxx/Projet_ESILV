using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


//Classe représentant le dictionnaire de mots utilisés dans le jeu
//Permet de vérifier la validité des mots joués par les joueurs
//Implémente des méthodes de recherche et de tri pour gérer efficacement les mots
//Le dictionnaire est initialisé à partir d'un fichier texte contenant les mots en français
//Utilise la recherche dichotomique pour vérifier l'existence d'un mot
//Utilise le tri fusion pour organiser les mots dans une liste triée

namespace projet
{
    class Dictionnaire
    {
        //Attributs
        private List<string> mots;

        //Constructeur
        public Dictionnaire()
        {
            using (StreamReader a = new StreamReader("Mots_Français.txt"))
            {
                mots = new List<string>(a.ReadToEnd().Split(' '));
            }
        }

        //Méthodes

        //Affiche tous les mots du dictionnaire (à des fins de test)
        public void AfficherDictionnaire() //Méthode de test
        {
            for(int i = 0; i < mots.Count; i++)
            {
                Console.Write($"{mots[i]} ");
            }
        }

        //Retourne une représentation textuelle du dictionnaire avec le nombre de mots par lettre initiale
        public override string ToString()
        {
            string result = "L'ensemble des mots du dictionnaire est en Français\n";
            int count;
            char[] lettres = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
            foreach (char lettre in lettres)
            {
                count = 0;
                foreach (string mot in mots)
                {
                    if (mot[0] == lettre)
                    {
                        count++;
                    }
                }
                result = result + "Il y a " + count + " mots qui commencent par la lettre " + lettre + "\n";
            }
            return result;
        }

        //Recherche dichotomique récursive pour trier le dictionnaire
        public bool RechDichoRecursif(string mot, List<string> liste = null)
        {
            if (liste == null)
            {
                liste = mots;
            }
            if (liste.Count == 0)
            {
                return false;
            }
            int milieu = liste.Count / 2;
            if (mot == liste[milieu])
            {
                return true;
            }
            else if (string.Compare(mot, liste[milieu]) < 0)
            {
                return RechDichoRecursif(mot, liste.GetRange(0, milieu));
            }
            else
            {
                return RechDichoRecursif(mot, liste.GetRange(milieu + 1, liste.Count - milieu - 1));
            }
        }

        //Tri fusion pour trier et fusionner la liste de mots
        public void Tri_Fusion()
        {
            mots = Tri_FusionRec(mots);
        }
        public List<string> Tri_FusionRec(List<string> tab = null)
        {
            if (tab == null)
            {
                tab = mots;
            }
            if (tab.Count <= 1)
            {
                return tab;
            }
            int milieu = tab.Count / 2;
            List<string> gauche = tab.GetRange(0, milieu);
            List<string> droite = tab.GetRange(milieu, tab.Count - milieu);
            gauche = Tri_FusionRec(gauche);
            droite = Tri_FusionRec(droite);
            return fusionner(gauche, droite);
        }
        public List<string> fusionner(List<string> gauche, List<string> droite)
        {
            List<string> resultat = new List<string>();
            int i = 0, j = 0;
            while (i < gauche.Count && j < droite.Count)
            {
                if (string.Compare(gauche[i], droite[j]) <= 0)
                {
                    resultat.Add(gauche[i]);
                    i++;
                }
                else
                {
                    resultat.Add(droite[j]);
                    j++;
                }
            }
            while (i < gauche.Count)
            {
                resultat.Add(gauche[i]);
                i++;
            }
            while (j < droite.Count)
            {
                resultat.Add(droite[j]);
                j++;
            }
            return resultat;
        }
    }
}