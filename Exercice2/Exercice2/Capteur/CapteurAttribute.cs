using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
    class CapteurAttribute : Attribute
    {
        public EnumType type;
        public EnumUnite unite;

        public CapteurAttribute(EnumType type, EnumUnite unite)
        {
            this.type = type;
            this.unite = unite;
        }
    }
}
