using Exercice2.Visualisation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Exercice2.Conversion;
using Exercice2.Enumerations;
using System.Linq;

namespace Exercice2.Capteur
{
    class Gestionnaire
    {
       
        private Dictionary<EnumUnite, EnumUnite> typesConversions;
        private Dictionary<SensorObject, Visualisateur> systeme;


        public Gestionnaire()
        {
           
            this.typesConversions = new Dictionary<EnumUnite, EnumUnite>();
            this.systeme = new Dictionary<SensorObject, Visualisateur>();

            updateTypesConversion();
           
        }

        public void updateTypesConversion()
        {
            Console.WriteLine();
            System.Console.WriteLine("Liste Convertisseurs");
            // reflection  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(typeof(Convertisseur));

            foreach (System.Attribute attr in attrs)
            {
                if (attr is ConvertisseurAttribute)
                {
                    ConvertisseurAttribute conAttribute = (ConvertisseurAttribute)attr;

                    //on teste si la clé n'existe pas déja
                    if (!typesConversions.ContainsKey(conAttribute.uniteEntree)){
                        typesConversions.Add(conAttribute.uniteEntree, conAttribute.uniteSortie);                       
                    }
                  
                }
            }

            for (int iterateur = 0; iterateur < typesConversions.Count; iterateur++)
            {
                Console.WriteLine(typesConversions.ElementAt(iterateur));
            }
            Console.WriteLine();
        }

        public void AjouterCapteur(SensorObject capteur)
        {


            // création d'un visualisateur
            BuilderVisualisateur builderConcrete = new BuilderConcrete(capteur.getType(),capteur.getUnite(), capteur.getDonnee());

            //ajout dans le dico 


            systeme.Add(capteur, builderConcrete.buildVisualisateur(capteur));


        }

        public void SupprimerCapteur(SensorObject capteur)
        {
         
                systeme.Remove(capteur);

        }

   
        public void mettreAjour()
        {
            Thread newThread = new Thread(new ThreadStart(sense)) { Name = "Thread de Sense()" };
            newThread.Start();
            
        }

        public void sense()
        {
            
            Console.WriteLine("/*************  Mise à jour des capteurs :" + String.Concat(" ********* Executed by ", Thread.CurrentThread.Name));
            Console.WriteLine();


            BuilderVisualisateur builderConcrete = new BuilderConcrete();
            foreach (KeyValuePair<SensorObject, Visualisateur> entry in systeme)
            {
                entry.Key.emettreDonnees();

                entry.Value.update(entry.Key);
                entry.Value.Visualiser();
            }

          
        }

        public void changeSystemeImperial()
        {
            Console.WriteLine();
            Console.WriteLine("/***********************************************/");
            Console.WriteLine("/**       CHANGEMENT SYSTEME IMPERIAL       ****/");
            Console.WriteLine("/***********************************************/");
         
            BuilderVisualisateur builderConcrete = new BuilderConcrete();
            foreach (KeyValuePair<SensorObject, Visualisateur> entry in systeme)
            {

                builderConcrete.buildNewSystemUnite(entry.Value);

                if (!typesConversions.ContainsKey(entry.Key.getUnite()))
                {
                    typesConversions.Add(entry.Key.getUnite(), entry.Value.getUnite());
                }
                
              
            }
            updateTypesConversion();
        }
    }
}
