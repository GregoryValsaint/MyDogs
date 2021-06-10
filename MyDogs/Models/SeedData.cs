using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDogs.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DogContext(
                serviceProvider.GetRequiredService<DbContextOptions<DogContext>>())) 
            {
                // Look for any dogs
                if (context.Dogs.Any())
                {
                    return;
                }

                context.Dogs.AddRange(
                    new Dog
                    {
                        Race = "Berger Australien",
                        Name = "Banzaï",
                        Age = 1,
                        Poids = 28.00
                    },
                    new Dog
                    {
                        Race = "Berger Australien",
                        Name = "Letto",
                        Age = 3,
                        Poids = 30.00
                    }, 
                    new Dog
                    {
                        Race = "Berger Australien",
                        Name = "Princesse",
                        Age = 8,
                        Poids = 32.00
                    }, 
                    new Dog
                    {
                        Race = "Berger Allemand",
                        Name = "Floyd",
                        Age = 10,
                        Poids = 32.00
                    }, 
                    new Dog
                    {
                        Race = "Caniche",
                        Name = "Igor",
                        Age = 13,
                        Poids = 9.00
                    }, 
                    new Dog
                    {
                        Race = "Labrador",
                        Name = "Swing",
                        Age = 15,
                        Poids = 25.00
                    }, 
                    new Dog
                    {
                        Race = "Teckel",
                        Name = "Wonki",
                        Age = 2,
                        Poids = 5.00
                    }, 
                    new Dog
                    {
                        Race = "Terre Neuve",
                        Name = "Albator",
                        Age = 1,
                        Poids = 50.00
                    }, 
                    new Dog
                    {
                        Race = "Carlin",
                        Name = "Pataud",
                        Age = 13,
                        Poids = 10.00
                    }, 
                    new Dog
                    {
                        Race = "Boxer",
                        Name = "Franck",
                        Age = 6,
                        Poids = 25.00
                    }, 
                    new Dog
                    {
                        Race = "Lévrier Afghan",
                        Name = "Précieuse",
                        Age = 9,
                        Poids = 26.00
                    }, 
                    new Dog
                    {
                        Race = "Yorkshire",
                        Name = "Kakou",
                        Age = 3,
                        Poids = 6.00
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
