using Exercice2.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Conversion
{
    class ConvertisseurAttribute : Attribute
    {

        public EnumUnite uniteEntree;
        public EnumUnite uniteSortie;

        public ConvertisseurAttribute(EnumUnite uniteEntree, EnumUnite uniteSortie)
        {
            this.uniteEntree = uniteEntree;
            this.uniteSortie = uniteSortie;
        }

      
    }

   
}
