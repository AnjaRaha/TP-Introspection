using Exercice2.Capteur;
using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace  Exercice2.Visualisation

{
    abstract class BuilderVisualisateur
    {
        protected Visualisateur visualisateur = new Visualisateur();
        public abstract void buildUnite(EnumUnite unite);
        public abstract void buildType(EnumType type);

        public abstract void buildValeur(Double valeur);

        public Visualisateur buildVisualisateur(SensorObject capteur)
        {
            FieldInfo[] fields = capteur.GetType().GetFields(
                       BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty |
                       BindingFlags.Instance);


            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals("unite"))
                {
                   // Console.WriteLine("unite "+field.GetValue(capteur));
                    visualisateur.setUnite((EnumUnite)field.GetValue(capteur));
                }

                if (field.Name.Equals("type"))
                {
                   // Console.WriteLine("type "+field.GetValue(capteur));
                    visualisateur.setType((EnumType)field.GetValue(capteur));
                }
                if (field.Name.Equals("donnee"))
                {
                    //Console.WriteLine("donneeé " + field.GetValue(capteur));
                    visualisateur.setValeur((Double)field.GetValue(capteur));
                }
            }

            
            return visualisateur;
        }

       

        public Visualisateur getVisualisateur() { return visualisateur; }
    }
}
