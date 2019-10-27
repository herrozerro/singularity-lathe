using System;
using System.Collections.Generic;
using System.Linq;
using SingularityLathe.Forge.Interfaces;

namespace SingularityLathe.Forge.StellarForge
{
    public class Population : IWeightedItem
    {
        public int ItemWeight { get; set; }
        public string Description { get; set; }

        public static List<Population> GetPopulations()
        {
            var pops = new List<Population>
            {
                new Population()
                {
                    Description = "Failed colonoy",
                    ItemWeight = 20
                },
                new Population()
                {
                    Description = "Outpost",
                    ItemWeight = 15
                },
                new Population()
                {
                    Description = "Tens of thousands",
                    ItemWeight = 15
                },
                new Population()
                {
                    Description = "Hundreds of thousands",
                    ItemWeight = 10
                },
                new Population()
                {
                    Description = "Millions",
                    ItemWeight = 10
                },
                new Population()
                {
                    Description = "Billions",
                    ItemWeight = 20
                },
                new Population()
                {
                    Description = "Alien Civilization",
                    ItemWeight = 5
                }
            };

            return pops;
        }

        public static Population GetRandomPopulation(Random rnd)
        {
            var pops = GetPopulations().Select(x => (IWeightedItem)x).ToList();

            return (Population)pops.GetRandomWeightedItem(rnd);
        }
    }


}
