using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
    [Capteur(EnumType.Humidite, EnumUnite.Unite2)]
    class Humidimetre : SensorObject
    {
        public Humidimetre()
        {
            Type t = typeof(Humidimetre);
            CapteurAttribute MyAttribute = (CapteurAttribute)Attribute.GetCustomAttribute(t, typeof(CapteurAttribute));

            setType(MyAttribute.type);
            setUnite(MyAttribute.unite);
        }
    }
}
