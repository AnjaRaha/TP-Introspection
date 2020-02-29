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

        public BuilderConcrete()
        {

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

        //methode qui change l'unité d'un visualisateur ; simulation d'un changement du systéme imperial
        public override void buildNewSystemUnite(Visualisateur visualisateur)
        {
            int uniteVisualValue = (int)visualisateur.getUnite();
            int enumMemberCount = Enum.GetNames(typeof(EnumUnite)).Length;

            for (int i=0; i< enumMemberCount; i++)
            {
                if (i != uniteVisualValue)
                {
                    visualisateur.setUnite((EnumUnite)i);
                }
            }
        }
    }
}
