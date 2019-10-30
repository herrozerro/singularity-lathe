using System;
using System.Collections.Generic;
using System.Linq;
using SingularityLathe.Forge.Interfaces;

namespace SingularityLathe.Forge.StellarForge
{
    public class TechLevel : IWeightedItem
    {
        public int ItemWeight { get; set; }
        public string Description { get; set; }

        public static List<TechLevel> GetTechLevels()
        {
            var techs = new List<TechLevel>
            {
                new TechLevel()
                {
                    Description = "Tech Level 0. Stone Age",
                    ItemWeight = 20
                },
                new TechLevel()
                {
                    Description = "Tech Level 1. Medieval",
                    ItemWeight = 15
                },
                new TechLevel()
                {
                    Description = "Tech Level 2. Nineteenth-century",
                    ItemWeight = 15
                },
                new TechLevel()
                {
                    Description = "Tech Level 3. Twentieth-century",
                    ItemWeight = 10
                },
                new TechLevel()
                {
                    Description = "Tech Level 4. Baseline postech",
                    ItemWeight = 10
                },
                new TechLevel()
                {
                    Description = "Tech Level 4 with specialties or some surviving pretech.",
                    ItemWeight = 20
                },
                new TechLevel()
                {
                    Description = "Tech Level 5. Pretech, pre-Silence tech.",
                    ItemWeight = 5
                }
            };

            return techs;
        }

        public static TechLevel GetRandomPopulation(Random rnd)
        {
            var tech = GetTechLevels().GetRandomWeightedItem(rnd);

            return (TechLevel)tech;
        }
    }


}
