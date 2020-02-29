using Exercice2.Capteur;
using Exercice2.Enumerations;
using Exercice2.Visualisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Conversion
{
    [Convertisseur(EnumUnite.Unite2, EnumUnite.Unite3)]

    class Convertisseur : Visualisateur, ISensor
    {
        public void emettreDonnees()
        {
            Console.WriteLine("**** CONVERSION ****");
        }
    }
}
