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
        
        public List<Lettre> Liste
        {
            get { return liste; }
            set { liste = value; }
        }
    }
}