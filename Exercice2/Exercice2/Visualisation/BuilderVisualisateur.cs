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

        public abstract void buildNewSystemUnite(Visualisateur visualisateur);

        public Visualisateur buildVisualisateur(SensorObject capteur)
        {
            visualisateur.update(capteur);
            return visualisateur;
        }

       

        public Visualisateur getVisualisateur() { return visualisateur; }
    }
}
