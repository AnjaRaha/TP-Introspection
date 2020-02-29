using Exercice2.Capteur;
using System;
using System.Threading;

namespace Exercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            /****************************** GESTIONNAIRE **********************************************/

            Gestionnaire gestionnaire = new Gestionnaire();

            /****************************** CAPTEURS **************************************************/

            //Creator de capteurs
            CreatorHumidimetre creatorHumidimetre = new CreatorHumidimetre();
            CreatorThermo creatorThermo = new CreatorThermo();

            //capteurs
            SensorObject thermometre = creatorThermo.CreationCapteur();
            SensorObject humidimetre = creatorHumidimetre.CreationCapteur();

            //ajout des capteurs dans le gestionnaire
            gestionnaire.AjouterCapteur(thermometre);
            gestionnaire.AjouterCapteur(humidimetre);

            //Mise à jour
           
          /*  gestionnaire.mettreAjour();
            Thread.Sleep(1000);
            gestionnaire.mettreAjour();
            Thread.Sleep(1000);
            gestionnaire.mettreAjour();
            Thread.Sleep(1000);*/

            for(int i=0; i < 3; i++)
            {
                gestionnaire.mettreAjour();
                Thread.Sleep(4000); 
            }



        }
    }
}
