using Exercice2.Capteur;
using Exercice2.Enumerations;
using Exercice2.Visualisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Conversion
{
    [Convertisseur(EnumUnite.Celcius, EnumUnite.Faranheit)]
    class Convertisseur : Visualisateur, ISensor
    {
        public void emettreDonnees()
        {
            throw new NotImplementedException();
        }
    }
}
