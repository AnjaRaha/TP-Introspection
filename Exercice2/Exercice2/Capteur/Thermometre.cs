using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
    [Capteur(EnumType.Temperature, EnumUnite.Unite1)]
    class Thermometre : SensorObject
    {
      public Thermometre()
        {
            Type t = typeof(Thermometre);
            CapteurAttribute MyAttribute = (CapteurAttribute)Attribute.GetCustomAttribute(t,typeof(CapteurAttribute));

            setType(MyAttribute.type);
            setUnite(MyAttribute.unite);
        }
    }
}
