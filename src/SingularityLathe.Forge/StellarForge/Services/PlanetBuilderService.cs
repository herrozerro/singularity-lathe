using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class PlanetBuilderService
    {
        private Planet planet = new Planet();
        private readonly Random rnd = null;

        public PlanetBuilderService(Random random)
        {
            rnd = random;
        }

        public PlanetBuilderService GeneratePhysicalProperties()
        {
            planet.Tempature = GetRandomTemp(rnd);
            planet.Atmosphere = GetRandomAtmosphere(rnd);
            planet.Biosphere = GetRandomBiosphere(rnd);

            return this;
        }

        public PlanetBuilderService GenerateLife()
        {
            if (planet.Biosphere.Description != "No native biosphere")
            {
                planet.Population = GetRandomPopulation(rnd);
                planet.TechLevel = GetRandomTechLevel(rnd);
            }

            return this;
        }

        private Tempature GetRandomTemp(Random rnd)
        {
            return Tempature.GetRandomTemperature(rnd);
        }
        private BioSphere GetRandomBiosphere(Random rnd)
        {
            return BioSphere.GetRandomBiosphere(rnd);
        }
        private Population GetRandomPopulation(Random rnd)
        {
            return Population.GetRandomPopulation(rnd);
        }
        private TechLevel GetRandomTechLevel(Random rnd)
        {
            return TechLevel.GetRandomPopulation(rnd);
        }
        private Atmosphere GetRandomAtmosphere(Random rnd)
        {
            return Atmosphere.GetRandomAtmosphere(rnd);
        }

        public void GeneratePlanet()
        {
            GeneratePhysicalProperties();
            GenerateLife();
        }

        public Planet BuildPlanet()
        {
            var newplanet = planet;
            planet = new Planet();
            return newplanet;
        }
    }
}
