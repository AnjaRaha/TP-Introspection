using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;


namespace Exercice2.Visualisation
{
    class BuilderConcrete : BuilderVisualisateur
    {
        public BuilderConcrete(EnumType type, EnumUnite unite, double valeur)
        {
            buildType(type);
            buildUnite(unite);
            buildValeur(valeur);
        }
        public override void buildType(EnumType type)
        {
            visualisateur.setType(type);
        }

        public override void buildUnite(EnumUnite unite)
        {
            visualisateur.setUnite(unite);
        }

        public override void buildValeur(double valeur)
        {
            visualisateur.setValeur(valeur);
        }
    }
}
