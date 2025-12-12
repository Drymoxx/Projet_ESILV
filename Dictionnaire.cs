using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projet
{
    class Dictionnaire
    {
        private List<string> mots;
        public Dictionnaire()
        {
            string contenu = File.ReadAllText("Mots_Français.txt");
            mots = contenu.Split(' ').ToList();
        }
        /*public void AfficherDictionnaire()
        {
            for(int i = 0; i < mots.Count; i++)
            {
                Console.Write($"{mots[i]} ");
            }
        }*/
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
    }
}