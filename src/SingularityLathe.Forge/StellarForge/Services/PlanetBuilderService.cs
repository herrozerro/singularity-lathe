using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class PlanetBuilderService
    {
        private Planet planet = new Planet();
        private readonly Random rnd = null;
        private readonly MoonBuilderService moonBuilderService = null;

        public PlanetBuilderService(Random random, MoonBuilderService moonBuilderService)
        {
            rnd = random;
            this.moonBuilderService = moonBuilderService;
        }

        public PlanetBuilderService GeneratePhysicalProperties()
        {
            planet.Tempature = GetRandomTemp();
            planet.Atmosphere = GetRandomAtmosphere();
            planet.Biosphere = GetRandomBiosphere();

            return this;
        }

        public PlanetBuilderService GenerateLife()
        {
            if (planet.Biosphere.Description != "No native biosphere")
            {
                planet.Population = GetRandomPopulation();
                planet.TechLevel = GetRandomTechLevel();
            }

            return this;
        }

        public PlanetBuilderService GenerateMoons()
        {
            int maxMoons = 2; //this should change depending on planet type, IE: Gas Giants should have more possible moons

            int moons = rnd.Next(maxMoons + 1);

            for (int i = 0; i < moons; i++)
            {
                moonBuilderService.GenerateMoon();
                planet.ChildBodies.Add(moonBuilderService.BuildMoon());
            }

            return this;
        }

        private Tempature GetRandomTemp()
        {
            return Tempature.GetRandomTemperature(rnd);
        }
        private BioSphere GetRandomBiosphere()
        {
            return BioSphere.GetRandomBiosphere(rnd);
        }
        private Population GetRandomPopulation()
        {
            return Population.GetRandomPopulation(rnd);
        }
        private TechLevel GetRandomTechLevel()
        {
            return TechLevel.GetRandomPopulation(rnd);
        }
        private Atmosphere GetRandomAtmosphere()
        {
            return Atmosphere.GetRandomAtmosphere(rnd);
        }

        public void GeneratePlanet()
        {
            GeneratePhysicalProperties();
            GenerateLife();
            GenerateMoons();
        }

        public Planet BuildPlanet()
        {
            var newplanet = planet;
            planet = new Planet();
            return newplanet;
        }
    }
}
