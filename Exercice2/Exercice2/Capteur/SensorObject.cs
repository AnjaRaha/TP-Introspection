using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
     class SensorObject : ISensor
    {
        protected  EnumType type;
        protected EnumUnite unite;
        protected Double donnee;

        public SensorObject(EnumType type, EnumUnite unite, double donnee)
        {
            this.type = type;
            this.unite = unite;
            this.donnee = donnee;
        }

        public SensorObject()
        {
            this.type = new EnumType();
            this.unite = new EnumUnite();
            emettreDonnees();
        }

        public void setType(EnumType type)
        {
            this.type = type;
        }

        public void setUnite(EnumUnite unite)
        {
            this.unite = unite;
        }

        public EnumType getType()
        {
            return this.type;
        }

        public EnumUnite getUnite()
        {
            return this.unite;
        }

        public Double getDonnee()
        {
            return this.donnee;
        }

        public void emettreDonnees()
        {
            Random random = new Random();
            donnee = (random.NextDouble() * (100 - (0)) + (0));
        }

        public void getClassName()
        {
            String className = this.GetType().Name;
            Console.WriteLine("Name:" + className);
        }
    }
}
