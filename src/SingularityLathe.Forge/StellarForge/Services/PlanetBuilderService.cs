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
        private readonly StellarForgeConfiguration stellarForgeConfiguration = null;


        public PlanetBuilderService(Random random, MoonBuilderService moonBuilderService, StellarForgeConfiguration stellarForgeConfiguration)
        {
            rnd = random;
            this.moonBuilderService = moonBuilderService;
            this.stellarForgeConfiguration = stellarForgeConfiguration;
        }

        public PlanetBuilderService GeneratePhysicalProperties()
        {
            planet.PlanetaryType = GetRandomPlanetaryType();
            planet.Tempature = GetRandomTemp();
            planet.Atmosphere = GetRandomAtmosphere();

            return this;
        }

        public PlanetBuilderService GenerateLife()
        {
            planet.Biosphere = GetRandomBiosphere();

            if (planet.Biosphere.Description != "No native biosphere")
            {
                //RARE GASGIANT WITH POPULATION AND TECHLEVEL
                if (planet.PlanetaryType.Description == "GASGIANT")
                {
                    if (rnd.Next(stellarForgeConfiguration.Odds_GasGiantLife) != 0)
                    {
                        return this;
                    }
                }

                planet.Population = GetRandomPopulation();
                planet.TechLevel = GetRandomTechLevel();
            }

            return this;
        }

        public PlanetBuilderService GenerateMoons()
        {
            int maxMoons = 2;
            int minMoons = 0;
            if (planet.PlanetaryType.Description == "GASGIANT")
            {
                maxMoons = stellarForgeConfiguration.Maxs_GasGiantMoons;
                minMoons = stellarForgeConfiguration.Mins_GasGiantMoons;
            }

            int moons = rnd.Next(minMoons,maxMoons + 1);

            for (int i = 0; i < moons; i++)
            {
                moonBuilderService.GenerateMoon();
                planet.ChildBodies.Add(moonBuilderService.BuildMoon());
            }

            return this;
        }

        private PlanetaryType GetRandomPlanetaryType()
        {
            return PlanetaryType.GetRandomPlanetaryType(rnd);
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
