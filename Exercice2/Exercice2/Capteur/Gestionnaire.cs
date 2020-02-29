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
        private List<SensorObject> listeCapteurs;
        private List<Visualisateur> listeVisualisateurs;
        private Dictionary<EnumUnite, EnumUnite> typesConversions;


        public Gestionnaire(List<SensorObject> listeCapteurs)
        {
            this.listeCapteurs = listeCapteurs;
        }

        public Gestionnaire()
        {
            this.listeCapteurs = new List<SensorObject>();
            this.listeVisualisateurs = new List<Visualisateur>();
            this.typesConversions = new Dictionary<EnumUnite, EnumUnite>();

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

            listeCapteurs.Add(capteur);

            // création d'un visualisateur
            BuilderVisualisateur builderConcrete = new BuilderConcrete(capteur.getType(),capteur.getUnite(), capteur.getDonnee());

            //ajout dans la liste des visualisateur avec le type et l'unité du capteur qu'on ajoute
            listeVisualisateurs.Add(builderConcrete.buildVisualisateur(capteur));


        }

        public void SupprimerCapteur(SensorObject capteur)
        {
                int indexCapteur = listeCapteurs.IndexOf(capteur);
                listeCapteurs.Remove(capteur);

                 //on supprime le visualisateur associé au capteur
                listeVisualisateurs.RemoveAt(indexCapteur);      
        }

   
        public void mettreAjour()
        {
            Thread newThread = new Thread(new ThreadStart(sense)) { Name = "Thread de mise à jour" };
            newThread.Start();
            
        }

        public void sense()
        {
            Console.WriteLine("/*************  Mise à jour des capteurs  ************/");
            Console.WriteLine();
            foreach (SensorObject capteur in listeCapteurs)
            {
                capteur.emettreDonnees();
            }


            //Liste capteurs
            Console.WriteLine(listeCapteurs);

            foreach (Visualisateur visual in listeVisualisateurs)
            {
                visual.Visualiser();
            }

            updateTypesConversion();
        }
    }
}
