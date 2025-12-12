using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet
{
    class Liste_Lettre
    {
        private List<Lettre> liste;

        public Liste_Lettre()
        {
            liste = new List<Lettre>();
            List<string> tab = new List<string>();
            using (StreamReader a = new StreamReader("Lettre.txt"))
            {
                string? line;
                while ((line = a.ReadLine()) != null || (line = a.ReadLine()) != "")
                {
                    tab.Add(line);
                }
            }
            foreach (string s in tab)
            {
                liste.Add(new Lettre(s));
            }
        }
        public List<Lettre> Liste
        {
            get { return liste; }
            set { liste = value; }
        }
    }
}