using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
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



    }
}
