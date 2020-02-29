using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
    class CreatorThermo : Creator
    {
        public override SensorObject CreationCapteur()
        {
            return new Thermometre();
        }
    }
}
