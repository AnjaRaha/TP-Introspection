using Exercice2.Capteur;
using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace  Exercice2.Visualisation

{
    class Visualisateur 
    {
        private EnumType type;
        private EnumUnite unite;
        private Double valeur;


        public Visualisateur(EnumType type, EnumUnite unite, Double valeur)
        {
            this.type = type;
            this.unite = unite;
            this.valeur = valeur;
        }

        public Visualisateur()
        {
            this.type = new EnumType();
            this.unite =  new EnumUnite();
            valeur = 0;
        }


        public void setType(EnumType type)
        {
            this.type = type;
        }

        public void setUnite(EnumUnite unite)
        {
            this.unite = unite;
        }

        public EnumType getType( )
        {
            return this.type;
        }

        public EnumUnite getUnite()
        {
            return this.unite;
        }

        public void setValeur(Double valeur)
        {
            this.valeur = valeur;
        }

        public Double getValeur()
        {
            return this.valeur;
        }

        public void Visualiser()
        {
            Console.WriteLine("/*******************/");
            Console.WriteLine("Type = " + getType());
            Console.WriteLine("Unite = " + getUnite());
            Console.WriteLine("Valeur =" + getValeur());
        }

        public void update(SensorObject capteur)
        {
            FieldInfo[] fields = capteur.GetType().GetFields(
                       BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty |
                       BindingFlags.Instance);


            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals("unite"))
                {
                    // Console.WriteLine("unite "+field.GetValue(capteur));
                    setUnite((EnumUnite)field.GetValue(capteur));
                }

                if (field.Name.Equals("type"))
                {
                    // Console.WriteLine("type "+field.GetValue(capteur));
                    setType((EnumType)field.GetValue(capteur));
                }
                if (field.Name.Equals("donnee"))
                {
                    //Console.WriteLine("donneeé " + field.GetValue(capteur));
                    setValeur((Double)field.GetValue(capteur));
                }
            }

        }


    }
}
