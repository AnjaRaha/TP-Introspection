using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Capteur
{
    class CreatorHumidimetre : Creator
    {
        public override SensorObject CreationCapteur()
        {
            return new Humidimetre();
        }
    }
}
