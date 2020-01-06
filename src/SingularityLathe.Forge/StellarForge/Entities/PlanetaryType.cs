using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class PlanetaryType : IWeightedItem
    {
        public int ItemWeight { get; set; }
        public string Description { get; set; }

        public static List<PlanetaryType> GetPlanetaryType()
        {
            var planetType = new List<PlanetaryType>
            {
                new PlanetaryType
                {
                    Description = "TERRESTRIAL",
                    ItemWeight = 10
                },
                new PlanetaryType
                {
                    Description = "GASGIANT",
                    ItemWeight = 5
                }
            };

            return planetType;
        }

        public static PlanetaryType GetRandomPlanetaryType(Random rnd)
        {
            var planetType = GetPlanetaryType().GetRandomWeightedItem(rnd);

            return (PlanetaryType)planetType;
        }
    }
}
