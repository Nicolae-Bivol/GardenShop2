using System.Collections.Generic;
using System.Data.Entity;
using GardenShop2.Domain.Model;

namespace GardenShop2.Domain.Data
{
     public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
     {
          protected override void Seed(ApplicationDbContext context)
          {
               var products = new List<Product>
            {
                new Product
                {
                    Name = "Apple Tree",
                    Category = "Trees",
                    Description = "Măr cu mere verzi",
                    FullDescription = "Un pom viguros, recunoscut pentru merele sale verzi și crocante, ideal pentru livezile de acasă.",
                    PreferredEnvironment = "Zone însorite, sol fertil cu drenaj bun.",
                    PlantingInstructions = "Se plantează primăvara devreme, la o distanță de 4–6 metri între pomi.",
                    CareInstructions = "Se taie anual, se fertilizează primăvara, se protejează de îngheț.",
                    ImageUrl = "/img/AppleTree.png",
                    Price = 25
                },
                new Product
                {
                    Name = "Cherry Blossom",
                    Category = "Trees",
                    Description = "Cireș cu flori roz",
                    FullDescription = "Cireșii japonezi sunt renumiți pentru florile lor spectaculoase de culoare roz, care apar în fiecare primăvară.",
                    PreferredEnvironment = "Soare direct, sol ușor acid și circulație bună a aerului.",
                    PlantingInstructions = "Se plantează toamna sau primăvara, la cel puțin 5 metri de alți copaci",
                    CareInstructions = "Se udă abundent în perioadele secetoase și se aplică mulci anual.",
                    ImageUrl = "/img/CherryBlossom.png",
                    Price = 30
                },
                new Product
                {
                    Name = "Rose",
                    Category = "Flowers",
                    Description = "Trandafir clasic de grădină",
                    FullDescription = "Trandafirul roșu clasic, simbol al iubirii. Ideal pentru grădini, buchete și borduri decorative.",
                    PreferredEnvironment = "Minim 6 ore de soare pe zi, sol bogat și bine drenat.",
                    PlantingInstructions = "Se plantează primăvara, în sol amestecat cu compost, la 50 cm distanță.",
                    CareInstructions = "Se udă la bază, se îndepărtează ramurile uscate, se adaugă mulci.",
                    ImageUrl = "/img/Rose.png",
                    Price = 10
                },
                new Product
                {
                    Name = "Shovel",
                    Category = "Tools",
                    Description = "Lopată solidă pentru grădinărit",
                    FullDescription = "Lopată din oțel durabil, ideală pentru săpat, ridicat sau mutat pământul și plantele.",
                    PreferredEnvironment = "Se păstrează într-un loc uscat pentru a preveni ruginirea.",
                    PlantingInstructions = "Utilizată pentru săparea paturilor de flori, îndepărtarea rădăcinilor și formarea marginilor.",
                    CareInstructions = "Se curăță după fiecare utilizare, iar părțile metalice se ung ocazional cu ulei.",
                    ImageUrl = "/img/Shovel.png",
                    Price = 15
                }
            };

               context.Products.AddRange(products);
               context.SaveChanges();
          }
     }
}
