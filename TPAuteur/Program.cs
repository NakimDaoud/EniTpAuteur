using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAuteur
{
    class Program
    {




        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {
            InitialiserDatas();

            var la = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));

            foreach (var auteur in la) {
                Console.WriteLine(auteur);
            }

            Console.WriteLine();
            var li = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l => l.Count()).First().Key;

            Console.WriteLine("Quel auteur a écrit le plus de livres");
            Console.WriteLine($"{li.Prenom} {li.Nom}");
            Console.WriteLine();

            var pacLiv = ListeLivres.GroupBy(l => l.Auteur);
            foreach (var liv in pacLiv) {
              Console.WriteLine($"Auteur : {liv.Key.Nom} {liv.Key.Prenom} moyennes des pages : {liv.Average(l => l.NbPages)}");
            }
            Console.WriteLine();
            var livreMax = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine($"livre : {livreMax.Titre} : {livreMax.NbPages}");


            var moyFact = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine();
            Console.WriteLine(" Moyenne des sommes : " + moyFact);

            var livresAlpha = ListeLivres.OrderBy(l => l.Titre);
            foreach (var livre in livresAlpha) {
                Console.WriteLine(livre);
            }

            Console.WriteLine();
            
            double moyennePage = ListeLivres.Average(l => l.NbPages);
            Console.WriteLine("nombre de page moyen : " + moyennePage);
            var livresSupMoy = ListeLivres.Where(l => l.NbPages > moyennePage);

            
            foreach (var livre in livresSupMoy) {
                Console.WriteLine($" livre :   {livre} {livre.NbPages}");
            }

            Console.WriteLine();
            var auteurMin = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l => l.Count()).Last().Key;

            Console.WriteLine("Quel auteur a écrit le moins de livres");
            Console.WriteLine($"{auteurMin.Prenom} {auteurMin.Nom}");
            Console.WriteLine();

            Console.ReadKey();
        }

        
    }
}
